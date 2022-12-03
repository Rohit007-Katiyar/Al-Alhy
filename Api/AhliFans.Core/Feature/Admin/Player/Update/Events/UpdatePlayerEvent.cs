using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Update.Events;

public record UpdatePlayerEvent(int PlayerId,int? PositionId,int? Number, string? Name, string? NameAr,
  DateTime? BirthDate, int? Height, int? Weight,int? CityOfBirth, string? Biography, string? BiographyAr, DateTime? DateSigned, 
  int? TeamCategoryId, string? FaceBookAccount, string? InstaAccount, string? TwitterAccount) : IRequest<ActionResult>;
