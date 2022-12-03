using AhliFans.Core.Feature.Security.ChangePassword.Fan.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.ChangePassword;

public class ChangePasswordEndPoint : EndpointBaseAsync
  .WithRequest<ChangePasswordRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangePasswordEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(ChangePasswordRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Change his password",
    Description = "Client Admin change his password",
    OperationId = "Client.ChangePassword",
    Tags = new[] {"Client Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(ChangePasswordRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangePasswordEvent(request.OldPassword, request.NewPassword, request.ConfirmPassword),
      cancellationToken);
}
