#nullable disable
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public class LeagueDates : BaseEntity<int>, IAggregateRoot
{
  public int Year { get; set; }
  public int LeagueId { get; set; }
  public virtual League League { get; set; }

  public bool IsDeleted { get; set; }
}
