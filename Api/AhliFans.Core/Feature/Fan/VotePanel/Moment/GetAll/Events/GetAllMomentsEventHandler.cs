using AhliFans.Core.Feature.Fan.VotePanel.Moment.GetAll.DTO;
using AhliFans.Core.Feature.Fan.VotePanel.Moment.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.VotePanel.Moment.GetAll.Events;

public class GetAllMomentsEventHandler : IRequestHandler<GetAllMomentsEvent,ActionResult>
{
  private readonly IRepository<Entities.Moment> _momentRepository;

  public GetAllMomentsEventHandler(IRepository<Entities.Moment> momentRepository)
  {
    _momentRepository = momentRepository;
  }
  public async Task<ActionResult> Handle(GetAllMomentsEvent request, CancellationToken cancellationToken)
  {
    var moments = await _momentRepository.ListAsync(new GetAllMoments(request.PageIndex,
      request.PageSize, request.MomentType),cancellationToken);
    if (moments.Count == 0) return new OkObjectResult(Enumerable.Empty<MomentDto>());

    return new OkObjectResult(moments.Select(m => new MomentDto(m.Id,
      request.Lang == Languages.En ? m.Player?.Name! : m.Player?.NameAr!, m.Player?.Number,
      request.Lang == Languages.En ? m.Match.OpponentTeam.Name : m.Match.OpponentTeam.NameAr, m.MomentTime?.ToString("h:mm tt")!, m.MomentTime?.ToString("dddd, dd MMMM yyyy")!)));
  }
}
