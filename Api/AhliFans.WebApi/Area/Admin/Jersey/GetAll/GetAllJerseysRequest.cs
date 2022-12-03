using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Jersey;

public record GetAllJerseysRequest(int PageIndex = 1, int PageSize = 10, bool IsEnabled = true, bool IsHome = true)
{
  public const string Route = $"{nameof(Areas.Admin)}/Jerseys";
}
