using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Stadium;

public record ChangeStatusRequest(int StadiumId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Stadium/Status";

}
