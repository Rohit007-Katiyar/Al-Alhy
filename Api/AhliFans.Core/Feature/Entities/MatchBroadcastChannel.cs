using System;
using System.Collections.Generic;

namespace AhliFans.Core.Feature.Entities;

public partial class MatchBroadcastChannel
{
  public int Id { get; set; }
  public int MatchId { get; set; }
  public int ChannelId { get; set; }

  public virtual BroadcastChannel Channel { get; set; } = null!;
  public virtual Match Match { get; set; } = null!;
}
