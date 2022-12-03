using AhliFans.Core.Feature.Admin.Team.TeamType.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Team.TeamType.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.TeamType.GetAll.Events;

public class GetAllEventHandler : IRequestHandler<GetAllTeamTypesEvent,ActionResult>
{
  private readonly IRepository<Entities.TeamType> _teamTypeRepository;

  public GetAllEventHandler(IRepository<Entities.TeamType> teamTypeRepository)
  {
    _teamTypeRepository = teamTypeRepository;
  }
  public async Task<ActionResult> Handle(GetAllTeamTypesEvent request, CancellationToken cancellationToken)
  {
    var teamTypes = await _teamTypeRepository.ListAsync(new GetAllTeamTypes(request.IsDeleted), cancellationToken);
    if (teamTypes.Count == 0) return new OkObjectResult(new AdminResponse("No data yet",ResponseStatus.Error));
    return new OkObjectResult(teamTypes.Select(t => new TeamTypesDto(t.Id, request.Lang == Languages.En?t.Name:t.NameAr,t.IsDeleted)));
  }
}
