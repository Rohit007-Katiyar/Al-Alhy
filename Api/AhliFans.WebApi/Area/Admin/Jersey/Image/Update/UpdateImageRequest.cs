using System.ComponentModel.DataAnnotations;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Jersey.Image;

public record UpdateImageRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Jersey/Image";
  
  [FromHeader]
  [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid value")]
  public int JerseyId { get; set; }
  
  [Required]
  public IFormFile JerseyImage { get; set; }
}
