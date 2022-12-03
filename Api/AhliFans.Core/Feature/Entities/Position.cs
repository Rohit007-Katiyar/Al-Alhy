using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public class Position : IAggregateRoot
{
  public Position()
  {
    MatchLineUps = new HashSet<MatchLineUp>();
    Players = new HashSet<Player>();
  }

  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public string? Symbol { get; set; }
  public DateTime Date { get; set; }
  public bool IsDeleted { get; set; }
  [ForeignKey("GeneralPosition")] public int? GeneralPositionId { get; set; }
  public virtual GeneralPlayerPosition? GeneralPosition { get; set; }
  public virtual ICollection<MatchLineUp> MatchLineUps { get; set; }
  public virtual ICollection<Player> Players { get; set; }
}
