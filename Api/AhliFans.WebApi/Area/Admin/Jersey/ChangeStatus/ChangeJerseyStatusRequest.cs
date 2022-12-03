using System.ComponentModel.DataAnnotations;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Jersey;

public class ChangeJerseyStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Jersey/Status";
  
  [FromHeader]
  [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid value")]
  public int JerseyId { get; set; }
}
