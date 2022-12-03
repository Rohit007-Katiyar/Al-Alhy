using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Region.Edit.Events;

public record EditRegionEvent(int Id, string? Name, string? NameAr) :IRequest<ActionResult>;
