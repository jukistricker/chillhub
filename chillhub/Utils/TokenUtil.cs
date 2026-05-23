using System.Security.Claims;
using System.Text;
using chillhub.Models.Enums;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace chillhub.Utils;

public sealed class TokenUtil
{
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly int _expireMinutes;
    private readonly JsonWebTokenHandler _handler;
    private readonly TokenValidationParameters _validationParameters;

    public TokenUtil(IConfiguration config)
    {
        _secretKey = config["Jwt:SecretKey"] ?? throw new ArgumentNullException("Jwt SecretKey missing");
        _issuer = config["Jwt:Issuer"] ?? throw new ArgumentNullException("Jwt Issuer missing") ;
        _audience = config["Jwt:Audience"] ?? throw new ArgumentNullException("Jwt Audience missing") ;
        _expireMinutes = int.Parse(config["Jwt:ExpireMinutes"] ?? "1440"); 
        _handler = new JsonWebTokenHandler(); 
        
        _validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:SecretKey"]!)),
            ValidateIssuer = true,
            ValidIssuer = config["Jwt:Issuer"] ,
            ValidateAudience = true,
            ValidAudience = config["Jwt:Audience"] ,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    }

    public Task<(string token, string jti)> GenerateToken(Guid userId, string username , LanguageEnum lang)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        if (lang != LanguageEnum.En)
        {
            lang = LanguageEnum.Vi;
        }
        
        string jti = Guid.NewGuid().ToString();

        var claims = new Dictionary<string, object>
        {
            [JwtRegisteredClaimNames.Sub] = userId.ToString(),      // UserId
            [JwtRegisteredClaimNames.Jti] = jti,
            [JwtRegisteredClaimNames.UniqueName] = username,        // Username
            ["lang"] = (int)lang                                  // Ngôn ngữ ưu tiên
        };

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = _issuer,
            Audience = _audience,
            Claims = claims,
            Expires = DateTime.UtcNow.AddMinutes(_expireMinutes),
            SigningCredentials = credentials
        };
        
        string token= _handler.CreateToken(descriptor);
        return Task.FromResult((token, jti));
    }

    public string? GetJti(string token)
    {
        var jwt = HandleJwt(token);
        return jwt.GetClaim(JwtRegisteredClaimNames.Jti).Value;
    }

    public JsonWebToken HandleJwt(string token)
    {
        if (!_handler.CanReadToken(token)) return null;
        var jwt = _handler.ReadJsonWebToken(token);
        return jwt;
    }

    public async Task<ClaimsPrincipal?> ValidateCryptoAsync(string token)
    {
        var result = await _handler.ValidateTokenAsync(token, _validationParameters);
        if (!result.IsValid)
        {
            Console.WriteLine($"Token Invalid: {result.Exception?.Message}");
            return null;
        }

        return new ClaimsPrincipal(result.ClaimsIdentity);
    }
}
