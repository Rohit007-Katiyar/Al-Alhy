#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;
public class City : BaseEntity<int>, IAggregateRoot
{
  public string Name { get; set; }
  public string NameAr { get; set; }

  [ForeignKey("Country")] public int CountryId { get; set; }
  public virtual Country Country { get; set; }
}
