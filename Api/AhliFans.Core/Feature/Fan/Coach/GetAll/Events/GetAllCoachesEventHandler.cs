using AhliFans.Core.Feature.Fan.Coach.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Coach.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Coach.GetAll.Events;
public class GetAllCoachesEventHandler : IRequestHandler<GetAllCoachesEvent,ActionResult>
{
  private readonly IRepository<Entities.Coach> _coachesRepository;
  public GetAllCoachesEventHandler(IRepository<Entities.Coach> coachesRepository)
  {
    _coachesRepository = coachesRepository;
  }
  public async Task<ActionResult> Handle(GetAllCoachesEvent request, CancellationToken cancellationToken)
  {
    var coaches = await _coachesRepository.ListAsync(new GetAllCoaches(request.IsCurrent,request.PageIndex,request.PageSize,request.SearchWord!,request.IsDeleted),cancellationToken);
    if (coaches.Count == 0) return new OkObjectResult(Enumerable.Empty<CoachesDto>());

    return new OkObjectResult(coaches.Select(c => new CoachesDto(c.Id, request.Lang == Languages.En ? c.City.Country.Name : c.City.Country.NameAr, request.Lang == Languages.En ? c.City.Name : c.City.NameAr, request.Lang == Languages.En ? c.Title.Text : c.Title.TextAr,
      request.Lang == Languages.En ? c.FirstName : c.FirstNameAr,
      request.Lang == Languages.En ? c.LastName : c.LastNameAr,c.IsCurrent,c.IsDeleted)));
  }
}
