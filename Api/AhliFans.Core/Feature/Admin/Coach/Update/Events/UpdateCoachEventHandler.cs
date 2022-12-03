using AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.Edit.Events;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Update.Events;

public class UpdateCoachEventHandler : IRequestHandler<UpdateCoachEvent, ActionResult>
{
  private readonly IMediator _mediator;
  private readonly IRepository<Entities.Coach> _coachRepository;
  public UpdateCoachEventHandler(IMediator mediator,IRepository<Entities.Coach> coachRepository)
  {
    _mediator = mediator;
    _coachRepository = coachRepository;
  }

  public async Task<ActionResult> Handle(UpdateCoachEvent request, CancellationToken cancellationToken)
  {
    var coach = await _coachRepository.GetByIdAsync(request.CoachId, cancellationToken);
    if (coach is null) return new BadRequestObjectResult(new AdminResponse("Not Found", ResponseStatus.Error));
    if (request.DateSigned > DateTime.Now) return new BadRequestObjectResult(new AdminResponse("Bad Signed Date", ResponseStatus.Error));

    MapCoach(request, ref coach);
    await _coachRepository.UpdateAsync(coach, cancellationToken);
    await _coachRepository.SaveChangesAsync(cancellationToken);

    await _mediator.Send(new EditCoachAccountEvent(coach.Id,request.FaceBookAccount,request.InstaAccount,request.TwitterAccount)
      ,cancellationToken);
    return new OkObjectResult(new AdminResponse("Operation done successfully.", ResponseStatus.Success));
  }

  private static void MapCoach(UpdateCoachEvent request, ref Entities.Coach coach)
  {
    coach.CityId = request.CityId == 0 ? coach.CityId : request.CityId;
    coach.CountryId = request.CountryId == 0 ? coach.CountryId : request.CountryId;
    coach.TitleId = request.TitleId == 0 ? coach.TitleId : request.TitleId;
    coach.FirstName = string.IsNullOrEmpty(request.FirstName) ? coach.FirstName : request.FirstName;
    coach.FirstNameAr = string.IsNullOrEmpty(request.FirstNameAr) ? coach.FirstNameAr : request.FirstNameAr;
    coach.LastName = string.IsNullOrEmpty(request.LastName) ? coach.LastName : request.LastName;
    coach.LastNameAr = string.IsNullOrEmpty(request.LastNameAr) ? coach.LastNameAr : request.LastNameAr;
    coach.Biography = string.IsNullOrEmpty(request.Biography) ? coach.Biography : request.Biography;
    coach.BiographyAr = string.IsNullOrEmpty(request.BiographyAr) ? coach.BiographyAr : request.BiographyAr;
    coach.IsCurrent = request.IsCurrent;
    coach.DateSigned = request.DateSigned ?? coach.DateSigned;
    coach.BirthDate = request.BirthDate ?? coach.BirthDate;
    coach.TeamCategoryId = request.TeamCategoryId ?? coach.TeamCategoryId;
  }
}
