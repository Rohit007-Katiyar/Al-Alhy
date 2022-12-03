using AhliFans.Core.Feature.Admin.Match.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Match.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.GetAll.Events;

public class GetAllEventHandler : IRequestHandler<GetAllMatchesEvent,ActionResult>
{
  private readonly IRepository<Entities.Match> _matchRepository;

  public GetAllEventHandler(IRepository<Entities.Match> matchRepository)
  {
    _matchRepository = matchRepository;
  }
  public async Task<ActionResult> Handle(GetAllMatchesEvent request, CancellationToken cancellationToken)
  {
    var matches = await _matchRepository.ListAsync(new GetAllMatches(request.PageIndex,request.PageSize,request.LeagueId,request.IsDeleted,request.IsAvailable,request.MatchTypes), cancellationToken);
    if (matches.Count == 0) return new BadRequestObjectResult(new AdminResponse("Not Data", ResponseStatus.Error));

    var matchesDto = matches.Where(x=>x.LeagueDateId == request.LeagueDataId).Select(m =>new MatchesDto(m.Id,m.IsDeleted,m.IsAvailable,m.PlannedDate, request.Lang == Languages.En?m.OpponentTeam.Name: m.OpponentTeam.NameAr,
      m.OpponentScore,m.Score,request.Lang == Languages.En?m.Stadium.Name: m.Stadium.NameAr,m.IsAway,
      m.Time,request.Lang == Languages.En?m.Referee.Name:m.Referee.NameAr));
    return new OkObjectResult(matchesDto);
  }
}
