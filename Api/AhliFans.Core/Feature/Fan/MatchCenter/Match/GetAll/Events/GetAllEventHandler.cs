using AhliFans.Core.Feature.Fan.MatchCenter.Match.GetAll.Specification;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Match;

public class GetAllEventHandler : IRequestHandler<GetAllMatchesEvent,ActionResult>
{
  private readonly IRepository<Entities.Match> _matchRepository;

  public GetAllEventHandler(IRepository<Entities.Match> matchRepository)
  {
    _matchRepository = matchRepository;
  }
  public async Task<ActionResult> Handle(GetAllMatchesEvent request, CancellationToken cancellationToken)
  {
    var matches = await _matchRepository.ListAsync(new GetAllMatchesByType(request.PageIndex,request.PageSize,request.MatchType), cancellationToken);
    if (matches.Count == 0) return new OkObjectResult(Enumerable.Empty<MatchCenterDto>());

    var matchesDto = matches.Select(m =>new MatchCenterDto(m.Id, request.Lang == Languages.En ? m.League.Name : m.League.NameAr, request.Lang == Languages.En?m.OpponentTeam.Name: m.OpponentTeam.NameAr,m.OpponentTeam.Id,
      m.OpponentScore,m.Score,request.Lang == Languages.En?m.Stadium.Name: m.Stadium.NameAr,m.IsAway,m.PlannedTime,request.Lang == Languages.En?m.Referee.Name:m.Referee.NameAr,m.PlannedDate.ToString("MMMM dd"), m.MatchType));
    return new OkObjectResult(matchesDto);
  }
}
