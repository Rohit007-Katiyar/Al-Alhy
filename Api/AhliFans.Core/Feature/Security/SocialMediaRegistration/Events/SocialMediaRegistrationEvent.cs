using AhliFans.Core.Feature.Security.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.SocialMediaRegistration.Events;

public record SocialMediaRegistrationEvent(string FullName, string? Email,
  string PhoneNumber, DateTime? BirthDate, int Country, int City, Gender? Gender = Gender.Male) : IRequest<ActionResult>;
