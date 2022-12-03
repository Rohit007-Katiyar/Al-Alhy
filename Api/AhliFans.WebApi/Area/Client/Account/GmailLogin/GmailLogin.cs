using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.GmailLogin.Fan.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.GmailLogin;

public class GmailLogin : EndpointBaseAsync
  .WithRequest<GmailLoginRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GmailLogin(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpPost(GmailLoginRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Login by his Gmail account",
    Description = "Client Login by his Gmail account ",
    OperationId = "Client.GmailLogin",
    Tags = new[] {"Client Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(GmailLoginRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GmailLoginEvent(request.Email, request.UserName), cancellationToken);
}
