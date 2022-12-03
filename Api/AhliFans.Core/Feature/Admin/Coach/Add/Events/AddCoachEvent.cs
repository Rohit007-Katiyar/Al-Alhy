using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Add.Events;

public record AddCoachEvent(int CityId,int CountryId, int TitleId, string FirstName, string FirstNameAr, string LastName,
  string LastNameAr, DateTime BirthDate, DateTime DateSigned, string Biography, string BiographyAr,
  IFormFile? Pic, bool IsCurrent, int TeamCategoryId, string? FaceBookAccount, string? InstaAccount, string? TwitterAccount) : IRequest<ActionResult>;
