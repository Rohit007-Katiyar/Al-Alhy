using Ardalis.Specification;

namespace AhliFans.SharedKernel.Interfaces
{
    // from Ardalis.Specification
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}