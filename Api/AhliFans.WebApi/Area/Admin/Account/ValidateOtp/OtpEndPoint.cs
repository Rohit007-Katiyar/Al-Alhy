using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.Login.Admin.DTO;
using AhliFans.Core.Feature.Security.ValidateOtp.Admin.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Account;

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
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin send the code that he received as sms",
    Description = "Admin send the code that he received as sms",
    OperationId = "Admin.ValidateOtp",
    Tags = new[] {"Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(OtpRequest request,
    CancellationToken cancellationToken = default) => 
    await _mediator.Send(new ValidateOtpEvent(request.PhoneNumber,request.Code),cancellationToken);
}
