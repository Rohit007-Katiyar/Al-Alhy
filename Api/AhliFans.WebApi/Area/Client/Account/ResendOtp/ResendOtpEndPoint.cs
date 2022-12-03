using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.ResendOtp.Fan.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.ResendOtp;

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
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Ask To Resend Otp",
    Description = "Client Ask To Resend Otp",
    OperationId = "Client.ResendOtp",
    Tags = new[] {"Client Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(ResendOtpRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ResendOtpEvent(request.PhoneNumber),cancellationToken);
}
