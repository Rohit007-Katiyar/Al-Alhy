#nullable disable
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public class League : BaseEntity<int>,IAggregateRoot
{
  public string Name { get; set; }
  public string NameAr { get; set; }
  public bool IsDeleted { get; set; }
  public ICollection<LeagueDates> Dates { get; set; }
  public DateTime Date { get; set; }
}
