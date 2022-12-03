using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Update.Events;

public record UpdateCoachEvent(int CoachId,int NationalityId, int CountryId, int CityId, int TitleId, string FirstName, string FirstNameAr, string LastName,
  string LastNameAr, DateTime? BirthDate, DateTime? DateSigned, string Biography, string BiographyAr,
  bool IsCurrent, int? TeamCategoryId, string? FaceBookAccount, string? InstaAccount, string? TwitterAccount) : IRequest<ActionResult>;
