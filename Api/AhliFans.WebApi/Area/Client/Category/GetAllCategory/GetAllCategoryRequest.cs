using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using JetBrains.Annotations;

namespace AhliFans.WebApi.Area.Client.Category.GetAllCategory;

public class GetAllCategoryRequest
{

  public const string Route = $"{nameof(Areas.Client)}/Categories";
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public bool IsDeleted { get; set; }
  public string Lang { get; set; } = Languages.En;
}
