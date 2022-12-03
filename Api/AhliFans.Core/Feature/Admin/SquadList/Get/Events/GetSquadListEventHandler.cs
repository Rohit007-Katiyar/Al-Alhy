using AhliFans.Core.Feature.Admin.SquadList.Get.Dto;
using AhliFans.Core.Feature.Admin.SquadList.Get.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.SquadList.Get.Events;

public class GetSquadListEventHandler : IRequestHandler<GetSquadListEvent, ActionResult>
{
  private readonly IRepository<Entities.SquadList> _squadListRepository;

  public GetSquadListEventHandler(IRepository<Entities.SquadList> squadListRepository)
  {
    _squadListRepository = squadListRepository;
  }

  public async Task<ActionResult> Handle(GetSquadListEvent request, CancellationToken cancellationToken)
  {
    var squadList = await _squadListRepository.ListAsync(new GetSquadListByMatchIdSpec(request.MatchId));

    var dtos = squadList.Select(sl => new SquadListPlayerDto
    {
      SquadListId = sl.Id,
      PlayerId = sl.PlayerId,
      PlayerName = request.Language == Languages.Ar ? sl.Player?.NameAr ?? string.Empty : sl.Player?.Name ?? string.Empty,
    });

    return new OkObjectResult(dtos);
  }
}
