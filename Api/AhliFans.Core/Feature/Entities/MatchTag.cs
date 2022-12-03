using System;
using System.Collections.Generic;

namespace AhliFans.Core.Feature.Entities;

public partial class MatchTag
{
  public int Id { get; set; }
  public int MatchId { get; set; }
  public int TagId { get; set; }

  public virtual Match Match { get; set; } = null!;
  public virtual Tag Tag { get; set; } = null!;
}