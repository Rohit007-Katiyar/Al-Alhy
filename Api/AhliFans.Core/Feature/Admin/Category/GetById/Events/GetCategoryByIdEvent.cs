using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Category.GetById.Events;
public record GetCategoryByIdEvent(int CategoryId, string Lang) : IRequest<ActionResult>;
