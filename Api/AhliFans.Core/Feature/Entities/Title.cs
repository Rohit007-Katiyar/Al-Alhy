using System;
using System.Collections.Generic;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class Title : IAggregateRoot
{
  public Title()
  {
    Coaches = new HashSet<Coach>();
  }

  public int Id { get; set; }
  public string Text { get; set; } = null!;
  public string TextAr { get; set; } = null!;
  public bool IsDeleted { get; set; }
  public DateTime Date { get; set; }

  public virtual ICollection<Coach> Coaches { get; set; }
}
