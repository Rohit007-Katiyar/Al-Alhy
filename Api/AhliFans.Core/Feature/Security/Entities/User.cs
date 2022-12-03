#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Enums;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel.Interfaces;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;

namespace AhliFans.Core.Feature.Security.Entities;
public class User : IdentityUser<Guid>, IAggregateRoot
{
  public virtual ICollection<UserClaim> Claims { get; set; }
  public virtual ICollection<UserLogin> Logins { get; set; }
  public virtual ICollection<UserToken> Tokens { get; set; }
  public virtual ICollection<UserRole> UserRoles { get; set; }
  public UserOtp Otp { get; set; }
  public bool IsBlocked { get; set; }
  public bool IsActive { get; set; }
  public DateTime RegistrationDate { get; set; }
  public string FullName { get; set; }
}
public class Admin : User
{
  public bool IsSuperAdmin { get; set; }
  [ForeignKey("UserCreate")] public Guid? CreatedBy { get; set; }
  [CanBeNull] public User UserCreate { get; set; }
  public DateTime CreatedOn { get; set; }
  [ForeignKey("UserModify")] public Guid? ModifiedBy { get; set; }
  [CanBeNull] public User UserModify { get; set; }
  public DateTime ModifiedOn { get; set; }
}
public class Fan : User
{
  public DateTime? BirthDate { get; set; }
  public Gender? Gender { get; set; }
  [CanBeNull] public string ProfilePic { get; set; }
  public Language? Language { get; set; }
  [ForeignKey("City")]public int? CityId { get; set; }
  [CanBeNull] public virtual City City { get; set; }
  [CanBeNull] public virtual ICollection<FanPreference> FanPreferences { get; set; }
  public string FireBaseToken { get; set; }
  public SocialMediaLink LinkedWith { get; set; } = SocialMediaLink.Null;
  public ICollection<FanNotification> FanNotifications { get; set; }

  public ICollection<UserMembership> Memberships { get; set; }
}


