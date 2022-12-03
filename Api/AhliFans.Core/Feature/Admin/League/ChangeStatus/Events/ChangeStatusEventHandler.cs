using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.League.ChangeStatus.Events; 
public class ChangeStatusEventHandler : IRequestHandler<ChangeLeagueStatusEvent,ActionResult>
{
  private readonly IRepository<Entities.League> _leagueRepository;

  public ChangeStatusEventHandler(IRepository<Entities.League> leagueRepository)
  {
    _leagueRepository = leagueRepository;
  }
  public async Task<ActionResult> Handle(ChangeLeagueStatusEvent request, CancellationToken cancellationToken)
  {
    var league = await _leagueRepository.GetByIdAsync(request.LeagueId, cancellationToken);
    if (league is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    league.IsDeleted = !league.IsDeleted;
    await _leagueRepository.UpdateAsync(league, cancellationToken);
    await _leagueRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(league.IsDeleted ? "Delete League Done You Can Retrieve It Any Time" : "Retrieve League Done You Can Delete It Any Time", ResponseStatus.Success));
  }

}
