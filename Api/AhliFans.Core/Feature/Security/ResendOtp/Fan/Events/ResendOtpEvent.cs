using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ResendOtp.Fan.Events;

public record ResendOtpEvent(string PhoneNumber):IRequest<ActionResult>;
