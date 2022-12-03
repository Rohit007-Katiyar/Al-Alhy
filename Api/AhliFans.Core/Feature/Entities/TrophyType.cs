using System;
using System.Collections.Generic;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class TrophyType : IAggregateRoot
{
  public TrophyType()
  {
    Trophies = new HashSet<Trophy>();
  }

  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public bool IsDeleted { get; set; }
  public DateTime Date { get; set; }

  public virtual ICollection<Trophy> Trophies { get; set; }
}
