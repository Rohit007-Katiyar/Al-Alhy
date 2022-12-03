using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Coach.Honor.GetById;

public record GetHonorByIdRequest(int HonorId,string Lang = Languages.En)
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Honor";
}
