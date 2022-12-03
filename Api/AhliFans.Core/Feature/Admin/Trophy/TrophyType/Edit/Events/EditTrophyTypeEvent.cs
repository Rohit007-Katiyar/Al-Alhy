using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.TrophyType.Edit.Events;

public record EditTrophyTypeEvent(int Id,string? Name,string? NameAr):IRequest<ActionResult>;
