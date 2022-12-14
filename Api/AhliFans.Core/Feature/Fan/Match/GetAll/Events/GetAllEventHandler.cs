using AhliFans.Core.Feature.Fan.Match.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Match.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Match.GetAll.Events;

public class GetAllEventHandler : IRequestHandler<GetAllMatchesEvent,ActionResult>
{
  private readonly IRepository<Entities.Match> _matchRepository;

  public GetAllEventHandler(IRepository<Entities.Match> matchRepository)
  {
    _matchRepository = matchRepository;
  }
  public async Task<ActionResult> Handle(GetAllMatchesEvent request, CancellationToken cancellationToken)
  {
    var matches = await _matchRepository.ListAsync(new GetAllMatches(request.PageIndex,request.PageSize,request.LeagueId,request.MatchType), cancellationToken);
    if (matches.Count == 0) return new OkObjectResult(Enumerable.Empty<MatchesDto>());

    var matchesDto = matches.Where(x=>x.LeagueDateId == request.LeagueDataId).Select(m =>new MatchesDto(m.Id, request.Lang == Languages.En ? m.League.Name : m.League.NameAr, request.Lang == Languages.En?m.OpponentTeam.Name: m.OpponentTeam.NameAr,m.OpponentTeam.Id,
      m.OpponentScore,m.Score,request.Lang == Languages.En?m.Stadium.Name: m.Stadium.NameAr,m.IsAway,m.PlannedTime,request.Lang == Languages.En?m.Referee.Name:m.Referee.NameAr,m.PlannedDate.ToString("MMMM dd")));
    return new OkObjectResult(matchesDto);
  }
}
