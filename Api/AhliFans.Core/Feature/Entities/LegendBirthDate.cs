using System;
using System.Collections.Generic;

namespace AhliFans.Core.Feature.Entities;

public partial class LegendBirthDate
{
  public LegendBirthDate()
  {
    MediaTags = new HashSet<MediaTag>();
  }

  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public DateTime BirthDate { get; set; }
  public string Description { get; set; } = null!;
  public string DescriptionAr { get; set; } = null!;
  public DateTime Date { get; set; }

  public virtual ICollection<MediaTag> MediaTags { get; set; }
}
