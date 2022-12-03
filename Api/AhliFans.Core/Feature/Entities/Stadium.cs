#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;
using JetBrains.Annotations;

namespace AhliFans.Core.Feature.Entities;

public partial class Stadium : IAggregateRoot
{
  public Stadium()
  {
    Matches = new HashSet<Match>();
  }

  public int Id { get; set; }
  [ForeignKey("Region")] public int? RegionId { get; set; }
  public string Name { get; set; } = null!;
  public string Location { get; set; } 
  public string NameAr { get; set; } = null!;
  public DateTime Date { get; set; }
  public bool IsDeleted { get; set; }
  [CanBeNull] public Region Region { get; set; } 
  public virtual ICollection<Match> Matches { get; set; }
}
