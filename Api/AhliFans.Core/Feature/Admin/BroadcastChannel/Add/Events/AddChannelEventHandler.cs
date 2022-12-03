using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.BroadcastChannel.Add.Events;

public class AddChannelEventHandler : IRequestHandler<AddChannelEvent,ActionResult>
{
  private readonly IRepository<Entities.BroadcastChannel> _channelRepository;

  public AddChannelEventHandler(IRepository<Entities.BroadcastChannel> channelRepository)
  {
    _channelRepository = channelRepository;
  }
  public async Task<ActionResult> Handle(AddChannelEvent request, CancellationToken cancellationToken)
  {
    await _channelRepository.AddAsync(new Entities.BroadcastChannel(){Date = DateTime.Now,Name = request.Name,NameAr = request.NameAr},cancellationToken);
    await _channelRepository.SaveChangesAsync(cancellationToken);
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
