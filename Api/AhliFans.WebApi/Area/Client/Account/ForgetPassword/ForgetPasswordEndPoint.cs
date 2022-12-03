using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.ForgotPassword.Fan.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.ForgetPassword;

public class ForgetPasswordEndPoint : EndpointBaseAsync
  .WithRequest<ForgetPasswordRequest>
  .WithActionResult
{

  private readonly IMediator _mediator;

  public ForgetPasswordEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpPost(ForgetPasswordRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Forget Password",
    Description = "Client Forget his password and need to reset it",
    OperationId = "Client.ForgetPassword",
    Tags = new[] { "Client Account Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromBody] ForgetPasswordRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ForgotPasswordEvent(request.FanPhoneNumber), cancellationToken);
}
