#nullable disable
using System.ComponentModel.DataAnnotations;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Coach.Image;

public record UpdateImageRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Image";
  [FromHeader] public int CoachId { get; set; }
  [Required]public IFormFile CoachImage { get; set; }
}
