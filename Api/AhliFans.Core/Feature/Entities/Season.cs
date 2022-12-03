using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.Core.Feature.Security.Entities;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class Season : IAggregateRoot
{
  public Season()
  {
    Honors = new HashSet<Honor>();
    Matches = new HashSet<Match>();
  }

  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public DateTime StartDate { get; set; }
  public DateTime? EndDate { get; set; }
  public DateTime? CreationDate { get; set; }
  public DateTime? ModifiedDate { get; set; }
  public bool IsDeleted { get; set; }
  [ForeignKey("CreatedBy")] public Guid? UserCreatedId { get; set; }
  [ForeignKey("ModifiedBy")]public Guid? UserModifiedId { get; set; }
  public virtual ICollection<Honor> Honors { get; set; }
  public virtual User? CreatedBy { get; set; }
  public virtual User? ModifiedBy { get; set; }
  public virtual ICollection<Match> Matches { get; set; }
}
