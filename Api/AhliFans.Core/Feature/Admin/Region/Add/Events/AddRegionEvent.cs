using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Region.Add.Events;

public record AddRegionEvent(string Name, string NameAr) :IRequest<ActionResult>;
