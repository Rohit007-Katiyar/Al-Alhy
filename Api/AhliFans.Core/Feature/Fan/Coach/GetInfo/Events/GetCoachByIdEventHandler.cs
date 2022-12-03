using AhliFans.Core.Feature.Fan.Coach.GetInfo.DTO;
using AhliFans.Core.Feature.Fan.Coach.GetInfo.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Coach.GetInfo.Events;
public class GetCoachByIdEventHandler : IRequestHandler<GetCoachByIdEvent,ActionResult>
{
  private readonly IRepository<Entities.Coach> _coachRepository;
  public GetCoachByIdEventHandler(IRepository<Entities.Coach> coachRepository)
  {
    _coachRepository = coachRepository;
  }

  public async Task<ActionResult> Handle(GetCoachByIdEvent request, CancellationToken cancellationToken)
  {
    var coach = await _coachRepository.GetBySpecAsync(new GetCoachById(request.CoachId),cancellationToken);
    if (coach is null) return new NotFoundObjectResult(new FanResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(new CoachDto(coach.Id, request.Lang == Languages.En ? coach.Country?.Name! : coach.Country?.NameAr!, request.Lang == Languages.En ?coach.City.Country.Name: coach.City.Country.NameAr, request.Lang == Languages.En?coach.City.Name:coach.City.NameAr, request.Lang == Languages.En ? coach.Title.Text: coach.Title.TextAr,
      request.Lang == Languages.En ? coach.FirstName : coach.FirstNameAr, request.Lang == Languages.En ? coach.LastName : coach.LastNameAr,
      coach.BirthDate, DateTime.Now.Year - coach.BirthDate.Year, coach.DateSigned, request.Lang == Languages.En ? coach.Biography : coach.BiographyAr,
      coach.IsCurrent, coach.Date,coach.IsDeleted));
  }
}
