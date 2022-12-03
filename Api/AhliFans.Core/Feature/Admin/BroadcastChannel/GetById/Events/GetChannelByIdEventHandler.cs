using AhliFans.Core.Feature.Admin.BroadcastChannel.GetById.DTO;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.BroadcastChannel.GetById.Events;

public class GetChannelByIdEventHandler : IRequestHandler<GetChannelByIdEvent,ActionResult>
{
  private readonly IRepository<Entities.BroadcastChannel> _channelRepository;

  public GetChannelByIdEventHandler(IRepository<Entities.BroadcastChannel> channelRepository)
  {
    _channelRepository = channelRepository;
  }
  public async Task<ActionResult> Handle(GetChannelByIdEvent request, CancellationToken cancellationToken)
  {
    var channel = await _channelRepository.GetByIdAsync(request.ChannelId,cancellationToken);
    if (channel == null) return new NotFoundObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    return new OkObjectResult(new ChannelDto(channel.Id,channel.Name,channel.NameAr));
  }
}
