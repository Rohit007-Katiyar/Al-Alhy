using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.MomentVideo.ChangeStatus;

public class ChangeMomentVideoStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/MomentVideo/Status";
  [FromHeader] public int MomentVideoId { get; set; }
}
