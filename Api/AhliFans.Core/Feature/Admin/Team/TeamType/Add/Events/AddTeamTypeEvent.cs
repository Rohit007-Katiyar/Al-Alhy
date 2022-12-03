using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.TeamType.Add.Events;

public record AddTeamTypeEvent(string Name, string NameAr):IRequest<ActionResult>;
