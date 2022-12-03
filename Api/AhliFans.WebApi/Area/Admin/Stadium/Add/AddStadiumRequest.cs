using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Stadium;

public record AddStadiumRequest(string Name,string NameAr,int RegionId,string Location)
{
  public const string Route = $"{nameof(Areas.Admin)}/Stadium";
}
