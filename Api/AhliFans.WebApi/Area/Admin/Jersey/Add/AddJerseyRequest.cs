using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Jersey;

public record AddJerseyRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Jersey";
  public IFormFile Picture { get; set; }
  public bool IsHome { get; set; }
}
