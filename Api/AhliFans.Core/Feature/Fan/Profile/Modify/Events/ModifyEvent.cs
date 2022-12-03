using AhliFans.Core.Feature.Security.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Profile.Modify.Events;

public record ModifyEvent(string? FullName, string? Email, string? PhoneNumber,
  DateTime? DateOfBirth, Gender? Gender,int? CityId) : IRequest<ActionResult>;
