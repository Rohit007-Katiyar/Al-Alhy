using System;
using System.Collections.Generic;

namespace AhliFans.Core.Feature.Entities;

public partial class MatchEventType
{
  public MatchEventType()
  {
    MatchEvents = new HashSet<MatchEvent>();
  }

  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public DateTime Date { get; set; }

  public virtual ICollection<MatchEvent> MatchEvents { get; set; }
}
