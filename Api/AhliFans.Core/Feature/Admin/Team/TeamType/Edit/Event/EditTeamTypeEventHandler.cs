using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.TeamType.Edit.Event;

public class EditTeamTypeEventHandler : IRequestHandler<EditTeamTypeEvent,ActionResult>
{
  private readonly IRepository<Entities.TeamType> _teamTypeRepository;

  public EditTeamTypeEventHandler(IRepository<Entities.TeamType> teamTypeRepository)
  {
    _teamTypeRepository = teamTypeRepository;
  }
  public async Task<ActionResult> Handle(EditTeamTypeEvent request, CancellationToken cancellationToken)
  {
    var teamType = await _teamTypeRepository.GetByIdAsync(request.TeamTypeId,cancellationToken);
    if (teamType == null) return new BadRequestObjectResult(new AdminResponse("Not found",ResponseStatus.Error));

    MapTeamType(request,ref teamType);

    await _teamTypeRepository.UpdateAsync(teamType, cancellationToken);
    await _teamTypeRepository.SaveChangesAsync(cancellationToken);
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private static void MapTeamType(EditTeamTypeEvent request, ref Entities.TeamType teamType)
  {
    teamType.Name = request.Name ?? teamType.Name;
    teamType.NameAr = request.NameAr ?? teamType.NameAr;
  }
}
