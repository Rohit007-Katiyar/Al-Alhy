using System.ComponentModel.DataAnnotations;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Category.ChangeStatus;

public class ChangeCategoryStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Category/Status";
  [FromHeader]
  [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid value")]
  public int CategoryId { get; set; }
}
