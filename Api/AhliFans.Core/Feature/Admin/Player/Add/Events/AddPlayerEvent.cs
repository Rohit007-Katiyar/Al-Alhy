using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Add.Events;

public record AddPlayerEvent(int? PositionId, int? Number, string? Name, string? NameAr,
  DateTime? BirthDate, int? Height, int? Weight, int? CityOfBirth, string? Biography, string? BiographyAr,
  IFormFile? Pic,DateTime? DateSigned, int? CountryHeLive, int TeamCategoryId, string? FaceBookAccount, string? InstaAccount, string? TwitterAccount) : IRequest<ActionResult>;

