using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.MomentVideo.GetById;

public class GetMomentVideoByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/MomentVideo/{{MomentVideoId}}";
  public int MomentVideoId { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
