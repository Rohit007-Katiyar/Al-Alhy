using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class MembershipCard : IAggregateRoot
{
  [Key]
  public int Id { get; set; }

  [ForeignKey(nameof(AdminCreate))] public Guid? CreatedBy { get; set; }

  [ForeignKey(nameof(AdminModify))] public Guid? ModifiedBy { get; set; }

  public DateTime CreatedOn { get; set; }

  public DateTime ModifiedOn { get; set; }

  public Security.Entities.Admin? AdminCreate { get; set; }

  public Security.Entities.Admin? AdminModify { get; set; }

  public string Type { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;

  public string DescriptionAr { get; set; } = string.Empty;

  public string TypeAr { get; set; } = string.Empty;

  public decimal Price { get; set; }

  public int Months { get; set; }

  public bool IsEnabled { get; set; }
}
