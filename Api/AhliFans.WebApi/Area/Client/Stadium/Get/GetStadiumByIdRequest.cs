using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Stadium;

public record GetStadiumByIdRequest(int StadiumId, string? Language)
{
  public const string Route = $"{nameof(Areas.Client)}/Stadium";
};
