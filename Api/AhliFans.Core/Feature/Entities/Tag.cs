using System;
using System.Collections.Generic;

namespace AhliFans.Core.Feature.Entities;

public partial class Tag
{
  public Tag()
  {
    MatchTags = new HashSet<MatchTag>();
  }

  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;

  public virtual ICollection<MatchTag> MatchTags { get; set; }
}