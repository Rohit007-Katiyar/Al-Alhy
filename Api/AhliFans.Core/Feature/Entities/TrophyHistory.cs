using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class TrophyHistory : IAggregateRoot
{
  public int Id { get; set; }
  public int TrophyId { get; set; }
  public int Year { get; set; }
  public DateTime Date { get; set; }

  public virtual Trophy Trophy { get; set; } = null!;
}
