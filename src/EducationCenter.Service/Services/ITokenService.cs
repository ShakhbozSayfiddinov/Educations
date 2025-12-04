using EducationCenter.Domain.Entities;
using EducationCenter.Service.Auth.Models;

namespace EducationCenter.Service.Services;

public interface ITokenService
{
    AuthResult Generate(User user);
}
