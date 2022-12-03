using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.ForgotPassword.Admin.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Account;

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
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Forget Password",
    Description = "Admin Forget his password and need to reset it",
    OperationId = "Admin.ForgetPassword",
    Tags = new[] { "Account Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] ForgetPasswordRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ForgotPasswordEvent(request.PhoneNumber), cancellationToken);
}
