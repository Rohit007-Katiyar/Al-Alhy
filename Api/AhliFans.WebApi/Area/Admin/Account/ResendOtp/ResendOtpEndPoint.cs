using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.ResendOtp.Admin.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Account;

public class ResendOtpEndPoint : EndpointBaseAsync
  .WithRequest<ResendOtpRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ResendOtpEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpPost(ResendOtpRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Ask To Resend Otp",
    Description = "Admin Ask To Resend Otp",
    OperationId = "Admin.ResendOtp",
    Tags = new[] { "Account Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(ResendOtpRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ResendOtpEvent(request.PhoneNumber),cancellationToken);
}
