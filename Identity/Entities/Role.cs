using Microsoft.AspNetCore.Identity;

namespace Identity.Entities;

public class Role : IdentityRole<int>
{
    private Role() { }

    public Role(string name)
    {
        Name = name;
        NormalizedName = name.ToUpperInvariant();
        Uuid = Guid.NewGuid();
    }

    public Guid Uuid { get; private set; }

    public bool IsDeleted { get; private set; }

    public void SoftDelete()
    {
        IsDeleted = true;
    }
}
