using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Stadium;

public record EditStadiumRequest(int StadiumId,int? RegionId, string? Name, string? NameAr,string? Location)
{
  public const string Route = $"{nameof(Areas.Admin)}/Stadium";

}
