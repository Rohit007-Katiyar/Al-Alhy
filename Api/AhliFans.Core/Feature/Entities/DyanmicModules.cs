using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;
public class DynamicModules : IAggregateRoot
{
  public DynamicModules()
  {

  }

  public long Id { get; set; }
  public byte ModuleType { get; set; }
  public byte SectionType { get; set; }
  public string Section { get; set; }
  public bool IsDeleted { get; set; }

  public DateTime CreatedDate { get; set; }
  public DateTime UpdatedDate { get; set; }
}
