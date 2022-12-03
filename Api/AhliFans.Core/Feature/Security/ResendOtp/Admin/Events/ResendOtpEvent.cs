using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ResendOtp.Admin.Events;

public record ResendOtpEvent(string PhoneNumber):IRequest<ActionResult>;
