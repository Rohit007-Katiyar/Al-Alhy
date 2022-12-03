using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Security.Entities;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;
public partial class Category : IAggregateRoot
{

  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public bool? photo { get; set; } = false;
  public bool? video { get; set; } = false;
  public bool? otd { get; set; } = false;
  public string Description { get; set; } = null!;
  public string DescriptionAr { get; set; } = null!;
  public DateTime CreatedOn { get; set; } = DateTime.Now;
  public DateTime? ModifiedOn { get; set; }
  public bool IsDeleted { get; set; }
  public Security.Entities.Admin? CreatedBy { get; set; }
  [ForeignKey(nameof(CreatedBy))]
  public Guid CreatedById { get; set; }

  public Security.Entities.Admin? ModifiedBy { get; set; }
  [ForeignKey(nameof(ModifiedBy))]
  public Guid? ModifiedById { get; set; }
}
