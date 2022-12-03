using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public class Team : IAggregateRoot
{
  public Team()
  {
    Matches = new HashSet<Match>();
  }

  public int Id { get; set; }
  public int TypeId { get; set; }
  [ForeignKey("Region")] public int? RegionId { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public string? Logo { get; set; } = null!;
  public DateTime Date { get; set; }
  public bool IsDeleted { get; set; }
  public Region? Region { get; set; } = null!;
  public virtual TeamType Type { get; set; } = null!;
  public virtual ICollection<Match> Matches { get; set; }
}
