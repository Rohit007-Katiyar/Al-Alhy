using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Client.Coach;

public record GetImageRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Coach/Image/{{CoachId}}";
  public int CoachId { get; set; }
}
