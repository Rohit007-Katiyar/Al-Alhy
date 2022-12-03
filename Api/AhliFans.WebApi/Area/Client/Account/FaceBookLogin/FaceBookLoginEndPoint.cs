using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.FBLogin.Fan.Events;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.FaceBookLogin;

public class FaceBookLoginEndPoint : EndpointBaseAsync
  .WithRequest<FaceBookLoginRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public FaceBookLoginEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpPost(FaceBookLoginRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Login by his facebook account",
    Description = "Client Login by his facebook account ",
    OperationId = "Client.FBLogin",
    Tags = new[] {"Client Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(FaceBookLoginRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new FbLoginEvent(request.AccessToken), cancellationToken);

}
