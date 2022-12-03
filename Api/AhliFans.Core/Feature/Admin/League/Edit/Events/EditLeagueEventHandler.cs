using AhliFans.Core.Feature.Admin.League.Edit.Specifications;
using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.League.Edit.Events;

public class EditLeagueEventHandler : IRequestHandler<EditLeagueEvent, ActionResult>
{
  private readonly IRepository<Entities.League> _leagueRepository;
  private readonly IRepository<LeagueDates> _leagueDateRepository;

  public EditLeagueEventHandler(IRepository<Entities.League> leagueRepository, IRepository<LeagueDates> leagueDateRepository)
  {
    _leagueRepository = leagueRepository;
    _leagueDateRepository = leagueDateRepository;
  }
  public async Task<ActionResult> Handle(EditLeagueEvent request, CancellationToken cancellationToken)
  {
    var league = await _leagueRepository.GetByIdAsync(request.LeagueId, cancellationToken);
    if (league == null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    league.Name = request.Name ?? league.Name;
    league.NameAr = request.NameAr ?? league.NameAr;

    await _leagueRepository.UpdateAsync(league, cancellationToken);
    await _leagueRepository.SaveChangesAsync(cancellationToken);

    if (request.LeagueDateTimes is not null)
    {
      await DeleteLeagueDates(request.LeagueId);
      var addDates = await AddLeagueDates(request, cancellationToken, league);
      if (!addDates) return new OkObjectResult(new AdminResponse("Add league done successfully but there is error in it's dates", ResponseStatus.Warning));
    }
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
  private async Task<bool> AddLeagueDates(EditLeagueEvent request, CancellationToken cancellationToken, Entities.League league)
  {
    if (request.LeagueDateTimes is null)
    {
      return true;
    }
    foreach (var date in request.LeagueDateTimes)
    {
      if (date > DateTime.Now.Year)
      {
        return false;
      }
      await _leagueDateRepository.AddAsync(new LeagueDates() { League = league, Year = date }, cancellationToken);
      await _leagueDateRepository.SaveChangesAsync(cancellationToken);
    }
    return true;
  }

  private async Task DeleteLeagueDates(int leagueId)
  {
    var leagueDatesList =
      await _leagueDateRepository.ListAsync(new GetAllLeagueDates(leagueId));

    foreach (var date in leagueDatesList)
    {
      date.IsDeleted = true;
    }
    await _leagueDateRepository.SaveChangesAsync();
  }
}
