using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.TeamType.Edit.Event;

public record EditTeamTypeEvent(int TeamTypeId,string? Name, string? NameAr) : IRequest<ActionResult>;
