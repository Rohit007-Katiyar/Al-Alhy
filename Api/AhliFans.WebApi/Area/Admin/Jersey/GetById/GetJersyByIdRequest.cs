using System.ComponentModel.DataAnnotations;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Jersey;

public record GetJerseyByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Jersey";

  [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid value")]
  public int JerseyId { get; set; }
}
