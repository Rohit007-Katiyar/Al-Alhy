using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class GetAllStatisticGroupsEventHandler : IRequestHandler<GetAllStatisticGroupsEvent, ActionResult>
{
  private readonly IRepository<Entities.MatchStatisticsType> _groupsRepository;

  public GetAllStatisticGroupsEventHandler(IRepository<MatchStatisticsType> groupsRepository)
  {
    _groupsRepository = groupsRepository;
  }

  public async Task<ActionResult> Handle(GetAllStatisticGroupsEvent request, CancellationToken cancellationToken)
  {
    var isArabic = request.Language == Languages.Ar;
    var statisticGroups = await _groupsRepository.ListAsync(new GetAllStatisticGroups(request.PageIndex, request.PageSize, request.Name), cancellationToken);

    var dtos = statisticGroups.Select(g => 
    {
      var name = isArabic ? g.NameAr : g.Name;
      var isEnabled = g.IsEnabled;
      var id = g.Id;
      return new StatisticGroupDto(id, name, isEnabled);
    });

    return new OkObjectResult(dtos);
  }
}
