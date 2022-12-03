#nullable disable
using System.ComponentModel.DataAnnotations;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Trophy.Image;

public record UpdateImageRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Trophy/Image";
  [FromHeader] public int TrophyId { get; set; }
  [Required]public IFormFile TrophyImage { get; set; }
}
