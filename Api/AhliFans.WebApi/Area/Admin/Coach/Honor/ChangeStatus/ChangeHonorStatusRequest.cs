using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Coach.Honor.ChangeStatus;

public record ChangeHonorStatusRequest(int HonorId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Honor";
}
