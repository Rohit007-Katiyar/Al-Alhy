using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.ResetForgetPassword.Fan.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.ResetPassword;

public class ResetPasswordEndPoint : EndpointBaseAsync
  .WithRequest<ResetPasswordRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ResetPasswordEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPost(ResetPasswordRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Reset his Forget Password",
    Description = "Client Reset his Forget Password",
    OperationId = "Client.ResetForgetPassword",
    Tags = new[] { "Client Account Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]ResetPasswordRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new FanResetPasswordEvent(request.NewPassword, request.ConfirmNewPassword),
      cancellationToken);
}
