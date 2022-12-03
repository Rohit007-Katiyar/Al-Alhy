using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.BroadcastChannel.GetAll.Events;

public record GetAllChannelsEvent(string Lang, int PageIndex, int PageSize):IRequest<ActionResult>;
