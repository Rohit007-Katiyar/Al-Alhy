using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public class Jersey : IAggregateRoot
{
  public int Id { get; set; }
  public string? Picture { get; set; }
  public bool IsHome { get; set; }
  public DateTime CreatedOn { get; set; } = DateTime.Now;
  public DateTime? ModifiedOn { get; set; }
  public bool IsEnabled { get; set; } = true;

  public Security.Entities.Admin? CreatedBy { get; set; }
  [ForeignKey(nameof(CreatedBy))]
  public Guid CreatedById { get; set; }

  public Security.Entities.Admin? ModifiedBy { get; set; }
  [ForeignKey(nameof(ModifiedBy))]
  public Guid? ModifiedById { get; set; }
}
