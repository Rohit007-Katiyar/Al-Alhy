using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.BroadcastChannel.Add.Events;

public record AddChannelEvent(string Name, string NameAr) : IRequest<ActionResult>;
