using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.BroadcastChannel.Edit.Events;

public class EditChannelEventHandler : IRequestHandler<EditChannelEvent,ActionResult>
{
  private readonly IRepository<Entities.BroadcastChannel> _channelRepository;

  public EditChannelEventHandler(IRepository<Entities.BroadcastChannel> channelRepository)
  {
    _channelRepository = channelRepository;
  }
  public async Task<ActionResult> Handle(EditChannelEvent request, CancellationToken cancellationToken)
  {
    var channel = await _channelRepository.GetByIdAsync(request.ChannelId, cancellationToken);
    if (channel == null) return new NotFoundObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    channel.Name = request.Name ?? channel.Name;
    channel.NameAr = request.NameAr ?? channel.NameAr;

    await _channelRepository.UpdateAsync(channel, cancellationToken);
    await _channelRepository.SaveChangesAsync(cancellationToken);
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
