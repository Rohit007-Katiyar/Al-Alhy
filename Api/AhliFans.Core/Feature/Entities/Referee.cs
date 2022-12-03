using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public class Referee : IAggregateRoot
{
  public Referee()
  {
    Matches = new HashSet<Match>();
  }

  public int Id { get; set; }
  [ForeignKey("Region")]public int? RegionId { get; set; }
  [ForeignKey("Nationality")]public int? NationalityId { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public bool IsDeleted { get; set; }
  public DateTime Date { get; set; }
  public Region? Region { get; set; }
  public Country? Nationality { get; set; }
  public ICollection<Match> Matches { get; set; }
}
