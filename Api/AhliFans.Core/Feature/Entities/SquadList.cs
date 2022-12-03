using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class SquadList : IAggregateRoot
{
  public int Id { get; set; }
  public int PlayerId { get; set; }
  public int MatchId { get; set; }
  public virtual Match Match { get; set; } = null!;
  public virtual Player Player { get; set; } = null!;

  public DateTime CreatedOn { get; set; }

  [ForeignKey(nameof(UserCreate))] public Guid? CreatedBy { get; set; } = null!;

  [ForeignKey(nameof(UserModify))] public Guid? ModifiedBy { get; set; } = null!;

  public DateTime ModifiedOn { get; set; }

  public Security.Entities.Admin? UserCreate { get; set; } = null!;

  public Security.Entities.Admin? UserModify { get; set; } = null!;
}
