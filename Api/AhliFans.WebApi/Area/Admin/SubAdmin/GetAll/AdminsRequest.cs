using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.SubAdmin;

public record AdminsRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/AllAdmins";

  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public bool IsBlocked{ get; set; } = false;

  public string? Name { get; set; }
  public string? Email { get; set; }
  public string? PhoneNumber { get; set; }
}
