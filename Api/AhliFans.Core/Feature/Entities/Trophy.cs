using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.Core.Feature.Security.Entities;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class Trophy : IAggregateRoot
{
  public Trophy()
  {
    TrophyHistories = new HashSet<TrophyHistory>();
  }

  public int Id { get; set; }
  public int TrophyTypeId { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public DateTime CreatedOn { get; set; }
  [ForeignKey("UserCreate")]public Guid? CreatedBy { get; set; }
  public DateTime? ModifiedOn { get; set; }
  [ForeignKey("UserModify")] public Guid? ModifiedBy { get; set; }
  public string? Picture { get; set; }
  public bool IsDeleted { get; set; }
  public bool IsAvailable { get; set; }


  public virtual TrophyType TrophyType { get; set; } = null!;
  public virtual User? UserCreate { get; set; } = null!;
  public virtual User? UserModify { get; set; } = null!;
  public virtual ICollection<TrophyHistory> TrophyHistories { get; set; }
}
