#nullable disable
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Coach.Title;

public record AddRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Title";
  public string Text { get; set; }
  public string TextAr { get; set; }
}
