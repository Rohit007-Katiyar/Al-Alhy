using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Category.GetById;

public class GetCategoryByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Category/{{CategoryId}}";
  public int CategoryId { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
