using System;
using System.Collections.Generic;

namespace AhliFans.Core.Feature.Entities;

public partial class PersonalAchievement
{
  public PersonalAchievement()
  {
    Honors = new HashSet<Honor>();
  }

  public int Id { get; set; }
  public string? Name { get; set; }
  public string? NameAr { get; set; }

  public virtual ICollection<Honor> Honors { get; set; }
}