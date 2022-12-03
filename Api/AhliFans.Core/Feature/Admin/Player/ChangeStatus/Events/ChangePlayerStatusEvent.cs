using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.ChangeStatus.Events;

public record ChangePlayerStatusEvent(int PlayerId):IRequest<ActionResult>;
