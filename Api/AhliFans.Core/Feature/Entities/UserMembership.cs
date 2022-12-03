using System.ComponentModel.DataAnnotations.Schema;

namespace AhliFans.Core.Feature.Entities;

public partial class UserMembership
{
  [ForeignKey(nameof(User))] public Guid UserId { get; set; }

  public DateTime CreatedOn { get; set; }

  public DateTime ExpireOn { get; set; }

  [NotMapped] public bool IsExpired { get => DateTime.Now > ExpireOn; }

  [ForeignKey(nameof(Card))] public int MembershipCardId { get; set; }

  public virtual Security.Entities.Fan? User { get; set; } = null!;

  public virtual MembershipCard? Card { get; set; } = null!;
}
