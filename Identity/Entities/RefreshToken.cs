using Identity.ValueObjects;

namespace Identity.Entities;

public class RefreshToken 
{
    private RefreshToken() { }//Only for EF

    public RefreshToken(int userId, TokenValue value, DateTime expiresAt)
    {
        UserId = userId;
        Value = value ?? throw new ArgumentNullException(nameof(value));
        ExpiresAt = expiresAt;
        IsRevoked = false;
        CreatedAt = DateTime.UtcNow;
    }

    public int UserId { get; private set; }
    public TokenValue Value { get; private set; }
    public DateTime ExpiresAt { get; private set; }
    public bool IsRevoked { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public bool IsValid() => !IsRevoked && DateTime.UtcNow < ExpiresAt;

    public void Revoke()
    {
        if (IsRevoked)
            return;

        IsRevoked = true;
    }
}
