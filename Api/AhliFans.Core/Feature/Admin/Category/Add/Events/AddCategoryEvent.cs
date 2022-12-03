using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Category.Add.Events;

public record AddCategoryEvent(string Name, string NameAr, bool photo, bool video, bool otd, string Description, string DescriptionAr, string AdminId) : IRequest<ActionResult>;
