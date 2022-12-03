using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.MediaPhoto.ChangeStatus;

public class ChangePhotoStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/MediaPhoto/Status";
  [FromHeader] public int PhotoId { get; set; }
}
