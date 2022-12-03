using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.BroadcastChannel.GetById.Events;

public record GetChannelByIdEvent(int ChannelId) : IRequest<ActionResult>;
