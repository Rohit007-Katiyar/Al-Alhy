#nullable disable
using System.ComponentModel.DataAnnotations;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Player.Image;

public record UpdateImageRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Player/Image";
  [FromHeader] public int PlayerId { get; set; }
  [Required]public IFormFile PlayerImage { get; set; }
}
