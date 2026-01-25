using Microsoft.AspNetCore.Identity;

namespace Identity.Entities;

public class User : IdentityUser<int>
{
    private User() { } // EF
    private readonly List<RefreshToken> _refreshTokens = new();

    public User(string userName, string email)
    {
        UserName = userName;
        Email = email;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        Uuid = Guid.NewGuid();
    }

    public Guid Uuid { get; private set; }

    public bool IsActive { get; private set; }
    public bool IsDeleted { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public IReadOnlyCollection<RefreshToken> RefreshTokens
        => _refreshTokens.AsReadOnly();

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SoftDelete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
    }

    public void AddRefreshToken(RefreshToken token)
    {
        _refreshTokens.Add(token);
    }

    public void RevokeAllTokens()
    {
        foreach (var token in _refreshTokens)
            token.Revoke();
    }
}
