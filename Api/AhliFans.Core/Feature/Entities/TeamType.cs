using System;
using System.Collections.Generic;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class TeamType : IAggregateRoot
{
  public TeamType()
  {
    Teams = new HashSet<Team>();
  }

  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public bool IsDeleted { get; set; } 


  public virtual ICollection<Team> Teams { get; set; }
}
