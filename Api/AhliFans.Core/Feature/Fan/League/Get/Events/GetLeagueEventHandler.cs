using AhliFans.Core.Feature.Fan.League.Get.DTO;
using AhliFans.Core.Feature.Fan.League.Get.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.League.Get.Events;

public class GetLeagueEventHandler : IRequestHandler<GetLeagueEvent,ActionResult>
{
  private readonly IRepository<Entities.League> _leagueRepository;

  public GetLeagueEventHandler(IRepository<Entities.League> leagueRepository)
  {
    _leagueRepository = leagueRepository;
  }
  public async Task<ActionResult> Handle(GetLeagueEvent request, CancellationToken cancellationToken)
  {
    var leagues =
      await _leagueRepository.ListAsync(new GetAllLeagues(request.LeagueId, request.LeagueName!), cancellationToken);
    if (leagues.Count == 0) return new OkObjectResult(Enumerable.Empty<LeaguesDto>());

    return new OkObjectResult(leagues.Select(l=>new LeaguesDto(l.Id,request.Lang == Languages.En? l.Name:l.NameAr,l.Dates.Select(d=>new LeagueDate(d.Id,d.Year)))));
  }
}
