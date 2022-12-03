using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Category.GetById.Events;
public record GetByCategoryIdEvent(int pageIndex, int pageSize, int CategoryId,string Lang) : IRequest<ActionResult>;
