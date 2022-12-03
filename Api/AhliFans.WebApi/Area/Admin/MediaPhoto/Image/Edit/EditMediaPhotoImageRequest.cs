#nullable disable
using System.ComponentModel.DataAnnotations;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.MediaPhoto.Image.Edit;

public class EditMediaPhotoImageRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/MediaPhoto/Image";
  [FromHeader] public int PhotoId { get; set; }
  [Required] public IFormFile PhotoImage { get; set; }
}
