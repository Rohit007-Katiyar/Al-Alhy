#nullable disable
using System.ComponentModel.DataAnnotations;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Team.Logo;

public record UpdateLogoRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Team/Logo";
  [FromHeader] public int TeamId { get; set; }
  [Required]public IFormFile TeamLogo { get; set; }
}
