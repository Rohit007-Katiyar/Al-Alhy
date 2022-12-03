using System;
using System.Collections.Generic;

namespace AhliFans.Core.Feature.Entities;

public partial class Video
{
  public Video()
  {
    MediaTags = new HashSet<MediaTag>();
  }

  public int Id { get; set; }
  public string FileName { get; set; } = null!;
  public bool IsMotion { get; set; }
  public bool IsActive { get; set; }
  public DateTime Date { get; set; }

  public virtual ICollection<MediaTag> MediaTags { get; set; }
}