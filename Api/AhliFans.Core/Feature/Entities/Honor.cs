using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;
using JetBrains.Annotations;

#nullable disable
namespace AhliFans.Core.Feature.Entities;

public class Honor:IAggregateRoot
{
  public int Id { get; set; }
  [ForeignKey("Trophy")]public int TrophyId { get; set; }
  public int? PlayerId { get; set; }
  public int? CoachId { get; set; }
  public bool IsDeleted { get; set; }
  public bool IsPersonal { get; set; }
  public DateTime Date { get; set; }

  [CanBeNull] public virtual Coach Coach { get; set; } = null!;
  [CanBeNull] public virtual Player Player { get; set; } = null!;
  public virtual Trophy Trophy { get; set; } = null!;
}
