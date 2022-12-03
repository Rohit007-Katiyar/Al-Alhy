using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class MatchGoal : IAggregateRoot
{
  [Key]
  public int Id { get; set; }

  [ForeignKey(nameof(Scorer))] public int? PlayerId { get; set; }

  [ForeignKey(nameof(Match))] public int MatchId { get; set; }

  public int Minute { get; set; }

  public bool IsForAhly { get; set; }

  public bool IsEnabled { get; set; }

  public virtual Player? Scorer { get; set; }

  public virtual Match Match { get; set; } = null!;

  public DateTime CreatedOn { get; set; }

  public DateTime ModifiedOn { get; set; }

  public Guid CreatedBy { get; set; }

  public Guid ModifiedBy { get; set; }

  public virtual Security.Entities.Admin? AdminCreate { get; set; } = null!;

  public virtual Security.Entities.Admin? AdminModify { get; set; } = null!;
}