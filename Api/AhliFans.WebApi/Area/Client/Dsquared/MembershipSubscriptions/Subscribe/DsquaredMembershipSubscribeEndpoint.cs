using AhliFans.Core;
using AhliFans.Core.Feature.Fan.Dsquared.MembershipSubscriptions.Subscribe;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Dsquared.MembershipSubscriptions;

public class DsquaredMembershipSubscribeEndpoint : EndpointBaseAsync
  .WithRequest<DsquaredMembershipSubscribeRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public DsquaredMembershipSubscribeEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Fan))]
  [HttpPost(DsquaredMembershipSubscribeRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Dsquared Membership Subscribe",
    Description = "Client Dsquared Membership Subscribe",
    OperationId = "Client.DsquaredMembershipSubscribe",
    Tags = new[] { "Dsquared Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] DsquaredMembershipSubscribeRequest request,
    CancellationToken cancellationToken = new CancellationToken())
  {
    var ev = new SubscribeEvent(request.RequestBody.MembershipCardId, request.RequestBody.Email, request.RequestBody.CardNumber, request.RequestBody.Cvv,
      request.RequestBody.ExpiryYear, request.RequestBody.ExpiryMonth, request.Lang ?? Languages.Ar);
    return await _mediator.Send(ev, cancellationToken);
  }
}
