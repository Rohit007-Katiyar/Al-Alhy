using System;
using System.Collections.Generic;

namespace AhliFans.Core.Feature.Entities;

public partial class Photo
{
  public Photo()
  {
    MediaTags = new HashSet<MediaTag>();
  }

  public int Id { get; set; }
  public string FileName { get; set; } = null!;
  public bool IsActive { get; set; }
  public DateTime Date { get; set; }

  public virtual ICollection<MediaTag> MediaTags { get; set; }
}