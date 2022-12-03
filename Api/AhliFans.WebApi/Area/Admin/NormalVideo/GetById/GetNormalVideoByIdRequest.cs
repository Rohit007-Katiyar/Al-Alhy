using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.NormalVideo.GetById;

public class GetNormalVideoByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/NormalVideo/{{NormalVideoId}}";
  public int NormalVideoId { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
