using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.Login.Fan.DTO;
using AhliFans.Core.Feature.Security.ValidateOtp.Fan.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.ValidateOtp;

public class OtpEndPoint : EndpointBaseAsync
  .WithRequest<OtpRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public OtpEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpPost(OtpRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(FanTokenDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client send the code that he received as sms",
    Description = "Client send the code that he received as sms",
    OperationId = "Client.ValidateOtp",
    Tags = new[] { "Client Account Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(OtpRequest request,
    CancellationToken cancellationToken = default) => 
    await _mediator.Send(new ValidateOtpEvent(request.PhoneNumber,request.Code),cancellationToken);
}
