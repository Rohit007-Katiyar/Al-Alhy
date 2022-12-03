using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.ChangeStatus.Events;
public record ChangeTeamStatusEvent(int TeamId) :IRequest<ActionResult>;
