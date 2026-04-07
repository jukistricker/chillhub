Set-Location $PSScriptRoot
$env:PGCLIENTENCODING = 'utf8'

$envPath = [System.IO.Path]::GetFullPath((Join-Path $PSScriptRoot "../../.env"))

if (-not (Test-Path $envPath)) {
    Write-Host "[ERROR] Khong tim thay file .env tai: $envPath" -ForegroundColor Red
    pause
    exit
}

Write-Host "--- Loading config from .env ---" -ForegroundColor Yellow
$envContent = Get-Content $envPath
foreach ($line in $envContent) {
    if ($line -match "^(?!\s*#)([^#=]+)=(.*)$") {
        $name = $matches[1].Trim()
        $value = $matches[2].Trim().Trim('"').Trim("'")
        [System.Environment]::SetEnvironmentVariable($name, $value)
    }
}

function Get-RequiredConfig($name) {
    $val = [System.Environment]::GetEnvironmentVariable($name)
    if ([string]::IsNullOrWhiteSpace($val)) { 
        Write-Host "[ERROR] Thieu bien trong .env: $name" -ForegroundColor Red
        return $null
    }
    return $val
}

$DB_HOST = Get-RequiredConfig "DB_HOST"
$DB_PORT = Get-RequiredConfig "DB_PORT"
$DB_USER = Get-RequiredConfig "DB_USER"
$DB_NAME = Get-RequiredConfig "DB_NAME"
$DB_PASS = Get-RequiredConfig "DB_PASS"

Write-Host "Database: $DB_HOST $DB_PORT $DB_USER $DB_NAME" -ForegroundColor Green

if ($null -eq $DB_HOST -or $null -eq $DB_PORT -or $null -eq $DB_USER -or $null -eq $DB_NAME -or $null -eq $DB_PASS) {
    pause
    exit
}

if ($DB_HOST -eq "postgres") { $DB_HOST = "localhost" }

if (-not (Get-Command psql -ErrorAction SilentlyContinue)) {
    Write-Host "[ERROR] Khong tim thay psql trong PATH!" -ForegroundColor Red
    pause
    exit
}

$SQL_DIR = Join-Path $PSScriptRoot "Migrate"
if (-not (Test-Path $SQL_DIR)) {
    Write-Host "[ERROR] Thu muc SQL khong ton tai: $SQL_DIR" -ForegroundColor Red
    pause
    exit
}

$env:PGPASSWORD = $DB_PASS
$files = Get-ChildItem -Path $SQL_DIR -Filter *.sql | Sort-Object Name

Write-Host "--- Starting Migration to $DB_HOST ($DB_NAME) ---" -ForegroundColor Green

foreach ($file in $files) {
    $fileName = $file.Name
    $filePath = $file.FullName
    Write-Host "Applying: $fileName" -ForegroundColor Cyan
    
    $psqlArgs = @("-h", $DB_HOST, "-p", $DB_PORT, "-U", $DB_USER, "-d", $DB_NAME, "-v", "ON_ERROR_STOP=1", "-f", $filePath)
    & psql @psqlArgs
    
    if ($LASTEXITCODE -ne 0) { 
        Write-Host "[LOI] Tai file: $fileName" -ForegroundColor Red
        $env:PGPASSWORD = $null
        pause
        exit $LASTEXITCODE 
    }
}

$env:PGPASSWORD = $null
Write-Host "MIGRATION SUCCESSFUL!" -ForegroundColor Green