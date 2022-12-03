using AhliFans.Core.Feature.Fan.SquadList.Get.Dto;
using AhliFans.Core.Feature.Fan.SquadList.Get.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.SquadList.Get.Events;

public class GetSquadListEventHandler : IRequestHandler<GetSquadListEvent, ActionResult>
{
  private readonly IRepository<Entities.SquadList> _repository;

  public GetSquadListEventHandler(IRepository<Entities.SquadList> repository)
  {
    _repository = repository;
  }

  public async Task<ActionResult> Handle(GetSquadListEvent request, CancellationToken cancellationToken)
  {
    var squadList = await _repository.ListAsync(new GetSquadListByMatchIdAndGeneralPosition(request.MatchId, request.GeneralPositionId), cancellationToken);
    var isArabic = request.Language == Languages.Ar;
    var dtos = squadList.Select(sl => new SquadListDto
    {
      MatchId = sl.MatchId,
      PlayerId = sl.PlayerId,
      PositionId = sl.Player.PositionId ?? 0,
      PlayerName = isArabic ? sl.Player.NameAr ?? string.Empty : sl.Player.Name ?? string.Empty,
      PlayerNumber = sl.Player.Number ?? 0,
      PositionName = isArabic ? sl.Player.Position?.NameAr ?? string.Empty : sl.Player.Position?.Name ?? string.Empty,
      PositionSymbol = sl.Player.Position?.Symbol ?? string.Empty
    });

    return new OkObjectResult(dtos);
  }
}
