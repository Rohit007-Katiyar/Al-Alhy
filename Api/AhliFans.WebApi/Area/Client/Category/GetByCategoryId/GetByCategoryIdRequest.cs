using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Client.Category.GetAllCategory;

public class GetByCategoryIdRequest
{

  public const string Route = $"{nameof(Areas.Client)}/Category";
  [FromHeader] public int CategoryId { get; set; }
  [FromHeader] public int PageIndex { get; set; }
  [FromHeader] public int PageSize { get; set; }
  public string Lang { get; set; } = Languages.En;
}
