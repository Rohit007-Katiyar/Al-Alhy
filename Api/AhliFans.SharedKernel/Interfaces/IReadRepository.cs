using Ardalis.Specification;

namespace AhliFans.SharedKernel.Interfaces
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}