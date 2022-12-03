namespace AhliFans.SharedKernel.Interfaces;

public interface ICustomQueryRepository : IDisposable
{
    Task<IEnumerable<T>> ListAsync<T>(string Query, object? param = null);
}