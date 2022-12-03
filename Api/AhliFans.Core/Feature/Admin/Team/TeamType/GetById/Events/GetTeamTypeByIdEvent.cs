using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.TeamType.GetById.Events;

public record GetTeamTypeByIdEvent(int TeamTypeId):IRequest<ActionResult>;
