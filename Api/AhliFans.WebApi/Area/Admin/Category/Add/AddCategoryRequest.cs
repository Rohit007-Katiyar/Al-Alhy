using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Category.Add;

public record AddCategoryRequest(int CategoryId, string Name, string NameAr ,string Description, string DescriptionAr, bool photo, bool video, bool otd)
{
  public const string Route = $"{nameof(Areas.Admin)}/Category";
}
