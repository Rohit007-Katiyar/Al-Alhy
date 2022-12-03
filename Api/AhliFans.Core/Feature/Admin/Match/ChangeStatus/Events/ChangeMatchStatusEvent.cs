using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.ChangeStatus.Events;
public record ChangeMatchStatusEvent(int MatchId) :IRequest<ActionResult>;
