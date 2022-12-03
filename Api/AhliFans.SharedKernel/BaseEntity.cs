#nullable disable
namespace AhliFans.SharedKernel;
public abstract class BaseEntity
  {
      public int Id { get; set; }

      public List<BaseDomainEvent> Events = new();
  }
public abstract class BaseEntity<TId> : BaseEntity
{
  public new TId Id { get; set; }
}
