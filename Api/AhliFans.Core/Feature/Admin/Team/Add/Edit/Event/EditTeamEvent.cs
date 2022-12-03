using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.Add.Edit.Event;

public record EditTeamEvent(int TeamId, int? TypeId, int? RegionId, string? Name, string? NameAr):IRequest<ActionResult>;
