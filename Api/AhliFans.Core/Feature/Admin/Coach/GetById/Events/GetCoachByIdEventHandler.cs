using AhliFans.Core.Feature.Admin.Coach.GetById.DTO;
using AhliFans.Core.Feature.Admin.Coach.GetById.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.GetById.Events;
public class GetCoachByIdEventHandler : IRequestHandler<GetCoachByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.Coach> _coachRepository;
  public GetCoachByIdEventHandler(IRepository<Entities.Coach> coachRepository)
  {
    _coachRepository = coachRepository;
  }

  public async Task<ActionResult> Handle(GetCoachByIdEvent request, CancellationToken cancellationToken)
  {
    var coach = await _coachRepository.GetBySpecAsync(new GetCoachById(request.CoachId), cancellationToken);
    if (coach is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    var teamCategoryName = request.Lang == Languages.Ar ? coach.TeamCategory?.NameAr ?? string.Empty : coach.TeamCategory?.Name ?? string.Empty;

    return new OkObjectResult(new CoachDto(coach.Id, coach.City.Country.Id.ToString(), coach.City.Id.ToString(), coach.Title.Id.ToString(),
       coach.FirstName, coach.FirstNameAr, coach.LastName, coach.LastNameAr, coach.BirthDate, coach.DateSigned,
       coach.Biography, coach.BiographyAr, coach.IsCurrent, coach.Date, coach.IsDeleted, teamCategoryName, coach.TeamCategoryId,coach.CountryId,
       request.Lang == Languages.En ? coach.Title.Text : coach.Title.TextAr, request.Lang == Languages.En ? coach.City.Country.Name : coach.City.Country.NameAr
       ));
  }
}
