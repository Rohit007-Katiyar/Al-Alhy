#nullable disable
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;
public class Country : BaseEntity<int>,IAggregateRoot
{
  public string Name { get; set; }
  public string NameAr { get; set; }
}
