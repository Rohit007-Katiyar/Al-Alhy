#nullable disable
using Microsoft.AspNetCore.Identity;

namespace AhliFans.Core.Feature.Security.Entities;
public class Role : IdentityRole<Guid>
{
    public Role() : base()
    {

    }
    public Role(string roleName) : this()
    {
        Name = roleName;
    }

     public virtual ICollection<UserRole> UserRoles { get; set; }
}