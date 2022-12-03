using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;

#nullable disable
namespace AhliFans.Core.Feature.Entities;
public class Region : BaseEntity<int>, IAggregateRoot
{
  public string Name { get; set; }
  public string NameAr { get; set; }
  public DateTime Date { get; set; }
  public bool Isdeleted { get; set; }
}
