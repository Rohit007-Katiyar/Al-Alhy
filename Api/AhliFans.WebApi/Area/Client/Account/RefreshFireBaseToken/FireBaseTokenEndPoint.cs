using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.RefreshFireBaseToken.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.RefreshFireBaseToken;

public class FireBaseTokenEndPoint : EndpointBaseAsync
  .WithRequest<FireBaseTokenRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public FireBaseTokenEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(FireBaseTokenRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client refresh fire base token",
    Description = "Client refresh fire base",
    OperationId = "Client.FireBaseToken",
    Tags = new[] {"Client Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(FireBaseTokenRequest request,
    CancellationToken cancellationToken = new CancellationToken()) =>
    await _mediator.Send(new FireBaseTokenEvent(request.Token), cancellationToken);
}
