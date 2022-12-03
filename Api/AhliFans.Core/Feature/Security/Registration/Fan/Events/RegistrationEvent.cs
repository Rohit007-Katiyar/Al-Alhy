using AhliFans.Core.Feature.Security.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.Registration.Fan.Events;
public record RegistrationEvent(string FullName, string? Email, string Password, string ConfirmPassword, string PhoneNumber, 
  Gender? Gender,  DateTime? BirthDate, int Country, int City, IFormFile? ProfilePic = null) : IRequest<ActionResult>;
