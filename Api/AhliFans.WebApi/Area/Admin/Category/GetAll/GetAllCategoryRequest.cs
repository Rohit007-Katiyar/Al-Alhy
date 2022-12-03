using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Category.GetAll;

public class GetAllCategoryRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Categories";
  public string? SearchWord { get; set; }
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public bool IsDeleted { get; set; }
  public string Lang { get; set; } = Languages.Ar;
  public string Type { get; set; } = String.Empty;
}
