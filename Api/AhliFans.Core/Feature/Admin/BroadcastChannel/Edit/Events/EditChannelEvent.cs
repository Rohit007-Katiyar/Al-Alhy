using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.BroadcastChannel.Edit.Events;

public record EditChannelEvent(int ChannelId,string? Name,string? NameAr):IRequest<ActionResult>;
