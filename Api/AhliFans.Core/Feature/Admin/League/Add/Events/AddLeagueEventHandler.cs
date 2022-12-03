using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.League.Add.Events;

public class AddLeagueEventHandler : IRequestHandler<AddLeagueEvent,ActionResult>
{
  private readonly IRepository<Entities.League> _leagueRepository;
  private readonly IRepository<LeagueDates> _leagueDateRepository;

  public AddLeagueEventHandler(IRepository<Entities.League> leagueRepository,IRepository<LeagueDates> leagueDateRepository)
  {
    _leagueRepository = leagueRepository;
    _leagueDateRepository = leagueDateRepository;
  }
  public async Task<ActionResult> Handle(AddLeagueEvent request, CancellationToken cancellationToken)
  {
    var league = new Entities.League {Name = request.Name, NameAr = request.NameAr, Date = DateTime.Now};
    await _leagueRepository.AddAsync(league, cancellationToken);
    await _leagueRepository.SaveChangesAsync(cancellationToken);

    var addDates = await AddLeagueDates(request, cancellationToken, league);
    if (!addDates) return new OkObjectResult(new AdminResponse("Add league done successfully but there is error in it's dates", ResponseStatus.Warning));
    return new OkObjectResult(new AdminResponse("Operation done successfully",ResponseStatus.Success));
  }

  private async Task<bool> AddLeagueDates(AddLeagueEvent request, CancellationToken cancellationToken, Entities.League league)
  {
    foreach (var date in request.LeagueDateTimes)
    {
      if (date > DateTime.Now.Year)
      {
        return false;
      }
      await _leagueDateRepository.AddAsync(new LeagueDates() {League = league, Year = date}, cancellationToken);
      await _leagueDateRepository.SaveChangesAsync(cancellationToken);
    }
    return true;
  }
}
