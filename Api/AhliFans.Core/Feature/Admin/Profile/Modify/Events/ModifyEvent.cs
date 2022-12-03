using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Profile.Modify.Events;

public record ModifyEvent(string? FullName, string? Email, string? PhoneNumber) : IRequest<ActionResult>;
