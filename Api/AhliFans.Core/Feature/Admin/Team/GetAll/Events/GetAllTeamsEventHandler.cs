using AhliFans.Core.Feature.Admin.Team.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Team.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.GetAll.Events;

public class GetAllTeamsEventHandler : IRequestHandler<GetAllTeamsEvent,ActionResult>
{
  private readonly IRepository<Entities.Team> _teamRepository;

  public GetAllTeamsEventHandler(IRepository<Entities.Team> teamRepository)
  {
    _teamRepository = teamRepository;
  }
  public async Task<ActionResult> Handle(GetAllTeamsEvent request, CancellationToken cancellationToken)
  {
    var (pageIndex, pageSize, teamName,isDeleted,lang) = request;

    var teams = await _teamRepository.ListAsync(new GetAllTeams(pageIndex, pageSize, teamName, isDeleted),cancellationToken);
    if (teams.Count == 0) return new OkObjectResult(new AdminResponse("No Data yet", ResponseStatus.Error));

    return new OkObjectResult(teams.Select(t => new TeamsDto(t.Id, lang == Languages.En ? t.Type.Name : t.Type.NameAr, lang == Languages.En ? t.Name : t.NameAr,t.IsDeleted)));
  }
}
