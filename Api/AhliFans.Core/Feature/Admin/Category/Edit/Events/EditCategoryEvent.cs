using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Category.Edit.Events;
public record EditCategoryEvent(int CategoryId, 
  string? Name, string? NameAr, string? Description, string? DescriptionAr, 
  bool photo,
  bool video,
  bool otd,
  string AdminId) : IRequest<ActionResult>;

