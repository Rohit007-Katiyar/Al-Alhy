using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.TeamType.ChangeStatus.Events;
public record ChangeTeamTypeStatusEvent(int TeamTypeId) :IRequest<ActionResult>;
