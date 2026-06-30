using System.ComponentModel.DataAnnotations;
using chillhub.Models.Dtos.Requests.Search;
using chillhub.Models.Enums;

namespace chillhub.Models.Dtos.Requests;

public class SignUpDto
{
    [Required(ErrorMessage = "auth.username_required")]
    public string Username { get; set; }
    [Required(ErrorMessage = "auth.email_required")]
    [EmailAddress(ErrorMessage = "auth.invalid_email_format")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "auth.password_required")]
    [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "auth.password_too_weak"
    )]
    public string Password { get; set; } = null!;

    public LanguageEnum InitLang { get; set; }
}

public class SignInDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class AuthFilterRequest : CursorRequest
{
    public Guid? Id { get; set; }
    public string? Username { get; set; }
}

public class RefreshTokenRequest
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}

public class UpdateProfileRequest
{
    public string? AvatarUrl { get; set; }
    public string FullName { get; set; } = null!;
    public LanguageEnum Lang { get; set; }
}

public class ChangePasswordRequest
{
    public string CurrentPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}