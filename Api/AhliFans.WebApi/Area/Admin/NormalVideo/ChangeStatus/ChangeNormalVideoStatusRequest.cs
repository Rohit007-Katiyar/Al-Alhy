using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.NormalVideo.ChangeStatus;

public class ChangeNormalVideoStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/NormalVideo/Status";
  [FromHeader] public int NormalVideoId { get; set; }
}
