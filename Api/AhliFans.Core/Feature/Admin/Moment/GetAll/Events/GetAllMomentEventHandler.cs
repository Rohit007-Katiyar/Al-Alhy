using AhliFans.Core.Feature.Admin.Moment.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Moment.GetAll.Specification;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment.GetAll.Events;

public class GetAllMomentEventHandler : IRequestHandler<GetAllMomentsEvent,ActionResult>
{
  private readonly IRepository<Entities.Moment> _momentRepository;

  public GetAllMomentEventHandler(IRepository<Entities.Moment> momentRepository)
  {
    _momentRepository = momentRepository;
  }
  public async Task<ActionResult> Handle(GetAllMomentsEvent request, CancellationToken cancellationToken)
  {
    var moments =
      await _momentRepository.ListAsync(new GetAllMoments(request.PageIndex, request.PageSize, request.IsAvailable),cancellationToken);
    if (moments.Count == 0) return new OkObjectResult(Enumerable.Empty<MomentsDto>());

    return new OkObjectResult(moments.Select(m => new MomentsDto(m.Id,
      request.Lang == Languages.En ? m.Player?.Name! : m.Player?.NameAr!,
      request.Lang == Languages.En ? m.Match.OpponentTeam.Name : m.Match.OpponentTeam.NameAr, m.Type, m.IsAvailable,
      m.MomentTime?.ToString("h:mm tt")!)));
  }
}
