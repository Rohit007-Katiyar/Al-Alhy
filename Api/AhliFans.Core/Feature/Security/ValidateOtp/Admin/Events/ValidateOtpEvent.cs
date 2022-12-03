using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ValidateOtp.Admin.Events;

public record ValidateOtpEvent(string PhoneNumber, string Code):IRequest<ActionResult>;
