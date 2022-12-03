using AhliFans.Core.Feature.Fan.MatchCenter.Coach.GetAll.DTO;
using AhliFans.Core.Feature.Fan.MatchCenter.Coach.GetAll.Specification;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Coach.GetAll.Events;

public class GetAllCurrentCoachesEventHandler : IRequestHandler<GetAllCurrentCoachesEvent,ActionResult>
{
  private readonly IRepository<Entities.Coach> _coachRepository;

  public GetAllCurrentCoachesEventHandler(IRepository<Entities.Coach> coachRepository)
  {
    _coachRepository = coachRepository;
  }
  public async Task<ActionResult> Handle(GetAllCurrentCoachesEvent request, CancellationToken cancellationToken)
  {
    var coaches = await _coachRepository.ListAsync(new GetAllCurrentCoaches(),cancellationToken);
    if (coaches.Count == 0) return new OkObjectResult(Enumerable.Empty<AllCurrentCoachesDto>());

    return new OkObjectResult(coaches.Select(c => new AllCurrentCoachesDto(c.Id,
      request.Lang == Languages.En ? c.FirstName + c.LastName : c.FirstNameAr + c.LastNameAr,
      request.Lang == Languages.En ? c.Title.Text : c.Title.TextAr)));
  }
}
