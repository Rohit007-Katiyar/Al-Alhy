
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Category.ChangeStatus.Events;
public record ChangeCategoryStatusEvent(int categoryId, string AdminId) : IRequest<ActionResult>;
