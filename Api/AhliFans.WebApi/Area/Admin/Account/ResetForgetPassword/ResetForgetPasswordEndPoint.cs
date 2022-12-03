using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.ResetForgetPassword.Admin.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Account;

public class ResetForgetPasswordEndPoint : EndpointBaseAsync
  .WithRequest<ResetForgetPasswordRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ResetForgetPasswordEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(ResetForgetPasswordRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Reset his Forget Password",
    Description = "Admin Reset his Forget Password",
    OperationId = "Admin.ResetForgetPassword",
    Tags = new[] {"Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]ResetForgetPasswordRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AdminForgetPasswordEvent(request.NewPassword, request.ConfirmNewPassword), cancellationToken);
}
