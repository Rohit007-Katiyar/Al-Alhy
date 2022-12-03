using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Coach.Honor.GetById;

public record GetHonorByIdRequest(int HonorId,string Lang = Languages.En)
{
  public const string Route = $"{nameof(Areas.Client)}/Coach/Honor";
}
