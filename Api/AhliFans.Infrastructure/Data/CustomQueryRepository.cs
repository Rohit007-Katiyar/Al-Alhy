using AhliFans.SharedKernel.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace AhliFans.Infrastructure.Data;

public class CustomQueryRepository : ICustomQueryRepository
{
  private readonly SqlConnection _connection;

  public CustomQueryRepository(IOptions<ConnectionHolder> connectionOptions)
  {
    var connString = connectionOptions.Value.Connection;
    _connection = new SqlConnection(connString);
  }

  public void Dispose()
  {
    GC.SuppressFinalize(this);
    _connection.Dispose();
  }

  public Task<IEnumerable<T>> ListAsync<T>(string query, object? param = null)
  {
    return _connection.QueryAsync<T>(query, param);
  }
}