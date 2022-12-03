using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.ResetPassword.Admin.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Account;

public class RestPasswordEndPoint : EndpointBaseAsync
  .WithRequest<RestPasswordRequest>
  .WithActionResult
{

  private readonly IMediator _mediator;
  public RestPasswordEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(RestPasswordRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Rest his Password",
    Description = "Active Admin Reset his password",
    OperationId = "Admin.RestPassword",
    Tags = new[] {"Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(RestPasswordRequest request,
    CancellationToken cancellationToken = default)
    => await _mediator.Send(new ResetPasswordEvent(request.NewPassword,request.ConfirmPassword),
      cancellationToken);
}
