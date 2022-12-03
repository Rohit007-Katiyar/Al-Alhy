using AhliFans.Core.Feature.Admin.League.GetDates.Specifications;
using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.League.GetDates.Events;

public class GetLeagueDatesEventHandler : IRequestHandler<GetLeagueDateEvent,ActionResult>
{
  private readonly IRepository<LeagueDates> _datesRepository;

  public GetLeagueDatesEventHandler(IRepository<LeagueDates> datesRepository)
  {
    _datesRepository = datesRepository;
  }
  public async Task<ActionResult> Handle(GetLeagueDateEvent request, CancellationToken cancellationToken)
  {
    var dates = await _datesRepository.ListAsync(new GetAllDatesByLeagueId(request.LeagueId),cancellationToken);
    if (dates.Count == 0) return new BadRequestObjectResult(new AdminResponse("No data yet", ResponseStatus.Error));
    return new OkObjectResult(dates.Select(l => new DTO.LeagueDates(l.Id, l.Year)));
  }
}
