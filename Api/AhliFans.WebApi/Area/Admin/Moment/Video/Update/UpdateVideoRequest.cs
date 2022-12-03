#nullable disable
using System.ComponentModel.DataAnnotations;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Moment;

public record UpdateVideoRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Moment/Video";
  [FromHeader] public int MomentId { get; set; }
  [Required]public IFormFile MomentVideo { get; set; }
}
