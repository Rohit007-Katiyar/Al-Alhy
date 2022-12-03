using AhliFans.Core.Feature.Admin.Team.TeamType.GetById.DTO;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.TeamType.GetById.Events;

public class GetByIdEventHandler : IRequestHandler<GetTeamTypeByIdEvent,ActionResult>
{
  private readonly IRepository<Entities.TeamType> _teamTypeRepository;

  public GetByIdEventHandler(IRepository<Entities.TeamType> teamTypeRepository)
  {
    _teamTypeRepository = teamTypeRepository;
  }
  public async Task<ActionResult> Handle(GetTeamTypeByIdEvent request, CancellationToken cancellationToken)
  {
    var teamType = await _teamTypeRepository.GetByIdAsync(request.TeamTypeId,cancellationToken);
    if (teamType == null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Success));
    return new OkObjectResult(new TeamTypeDto(teamType.Id, teamType.Name, teamType.NameAr));
  }
}
