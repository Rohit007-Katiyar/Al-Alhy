using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Fans;

public record GetAllRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Fans";
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public string? SearchWord { get; set; }
  public bool IsBlocked { get; set; }
}
