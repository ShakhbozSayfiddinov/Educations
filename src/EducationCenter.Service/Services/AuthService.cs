using EducationCenter.Domain.Entities;
using EducationCenter.Infrastructure.Persistence;
using EducationCenter.Service.Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationCenter.Service.Services;

public interface IAuthService
{
    ValueTask<AuthResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    ValueTask<AuthResult> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
}

public class AuthService(AppDbContext dbContext, ITokenService tokenService) : IAuthService
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly ITokenService _tokenService = tokenService;

    public async ValueTask<AuthResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            throw new ArgumentException("Email va parol kiritilishi shart.");
        }

        var user = await _dbContext.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(
                u => u.Email == request.Email && !u.IsDeleted,
                cancellationToken)
            .ConfigureAwait(false);

        if (user == null || !string.Equals(user.Password, request.Password, StringComparison.Ordinal))
        {
            throw new UnauthorizedAccessException("Email yoki parol noto'g'ri.");
        }

        return _tokenService.Generate(user);
    }

    public async ValueTask<AuthResult> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            throw new ArgumentException("Email va parol kiritilishi shart.");
        }

        var emailExists = await _dbContext.Users
            .AnyAsync(u => u.Email == request.Email && !u.IsDeleted, cancellationToken)
            .ConfigureAwait(false);

        if (emailExists)
        {
            throw new ArgumentException("Bu email bilan foydalanuvchi mavjud.");
        }

        var roleId = request.RoleId ?? 2; // Default: Student

        var role = await _dbContext.Roles
            .FirstOrDefaultAsync(r => r.Id == roleId && r.IsActive && !r.IsDeleted, cancellationToken)
            .ConfigureAwait(false);

        if (role == null)
        {
            throw new ArgumentException("Rol topilmadi yoki faol emas.");
        }

        var now = DateTime.UtcNow;
        var user = new User
        {
            Email = request.Email,
            Password = request.Password,
            RoleId = role.Id,
            CreatedAt = now,
            UpdatedAt = now
        };

        await _dbContext.Users.AddAsync(user, cancellationToken).ConfigureAwait(false);
        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        user.Role = role;
        return _tokenService.Generate(user);
    }
}
