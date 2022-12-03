using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.Add.Edit.Event;

public class EditEventHandler : IRequestHandler<EditTeamEvent,ActionResult>
{
  private readonly IRepository<Entities.Team> _teamRepository;

  public EditEventHandler(IRepository<Entities.Team> teamRepository)
  {
    _teamRepository = teamRepository;
  }
  public async Task<ActionResult> Handle(EditTeamEvent request, CancellationToken cancellationToken)
  {
    var team = await _teamRepository.GetByIdAsync(request.TeamId, cancellationToken);
    if (team == null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    MapTeam(request,ref team);
    await _teamRepository.UpdateAsync(team, cancellationToken);
    await _teamRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private static void MapTeam(EditTeamEvent request, ref Entities.Team team)
  {
    team.TypeId = request.TypeId ?? team.TypeId;
    team.Name = request.Name ?? team.Name;
    team.RegionId = request.RegionId ?? team.RegionId;
    team.NameAr = request.NameAr ?? team.NameAr;
  }
}
