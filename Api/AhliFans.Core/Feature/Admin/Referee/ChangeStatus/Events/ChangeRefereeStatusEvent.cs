using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Referee.ChangeStatus.Events;
public record ChangeRefereeStatusEvent(int RefereeId) :IRequest<ActionResult>;
