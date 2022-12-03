using AhliFans.Core.Feature.Fan.Referee.GetByMatch.DTO;
using AhliFans.Core.Feature.Fan.Referee.GetByMatch.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Referee.GetByMatch.Events;

public class GetRefereeEventHandler : IRequestHandler<GetRefereeByMatchEvent,ActionResult>
{
  private readonly IRepository<Entities.Match> _matchRepository;

  public GetRefereeEventHandler(IRepository<Entities.Match> matchRepository)
  {
    _matchRepository = matchRepository;
  }
  public async Task<ActionResult> Handle(GetRefereeByMatchEvent request, CancellationToken cancellationToken)
  {
    var referee = await _matchRepository.GetBySpecAsync(new GetRefereeByMatch(request.MatchId),cancellationToken);
    if (referee == null) return new NotFoundObjectResult(new FanResponse("No found",ResponseStatus.Error));

    return new OkObjectResult(new RefereeByMatchDto(referee.RefereeId, request.Lang == Languages.En? referee.Referee.Name: referee.Referee.NameAr, request.Lang == Languages.En ? referee.Referee.Nationality?.Name! : referee.Referee.Nationality?.NameAr!));
  }
}
