using AhliFans.Core.Feature.Security.Enums;
using System.ComponentModel.DataAnnotations;

namespace AhliFans.WebApi.Area.Admin.Category.Edit;
public record EditCategoryRequest(int CategoryId, string? Name, string? NameAr, string? Description, string? DescriptionAr, bool photo, 
  bool video, bool otd)
{
  public const string Route = $"{nameof(Areas.Admin)}/Categories";
}
