namespace EducationCenter.Service.Auth.Models;

public record AuthResult(string AccessToken, DateTime ExpiresAt, string Email, string Role);
