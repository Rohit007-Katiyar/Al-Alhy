using System.Security.Cryptography.X509Certificates;
using AhliFans.Core.Feature.Admin.BroadcastChannel.GetAll.DTO;
using AhliFans.Core.Feature.Admin.BroadcastChannel.GetAll.Specification;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.BroadcastChannel.GetAll.Events;

public class GetAllChannelsEventHandler : IRequestHandler<GetAllChannelsEvent,ActionResult>
{
  private readonly IRepository<Entities.BroadcastChannel> _channelRepository;

  public GetAllChannelsEventHandler(IRepository<Entities.BroadcastChannel> channelRepository)
  {
    _channelRepository = channelRepository;
  }
  public async Task<ActionResult> Handle(GetAllChannelsEvent request, CancellationToken cancellationToken)
  {
    var channels = await _channelRepository.ListAsync(new GetAllChannels(request.PageIndex, request.PageSize),cancellationToken);
    if (channels.Count == 0) return new NotFoundObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(channels.Select(c =>
      new ChannelsDto(c.Id, request.Lang == Languages.En ? c.Name : c.NameAr)));
  }
}
