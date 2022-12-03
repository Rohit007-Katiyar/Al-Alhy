using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class BroadcastChannel : IAggregateRoot
{
  public BroadcastChannel()
  {
    MatchBroadcastChannels = new HashSet<MatchBroadcastChannel>();
  }

  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public DateTime Date { get; set; }

  public virtual ICollection<MatchBroadcastChannel> MatchBroadcastChannels { get; set; }
}
