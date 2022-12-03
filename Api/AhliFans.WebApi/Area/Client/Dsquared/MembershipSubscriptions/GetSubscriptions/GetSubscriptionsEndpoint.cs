using AhliFans.Core;
using AhliFans.Core.Feature.Fan.Dsquared.MembershipSubscriptions;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Dsquared.MembershipSubscriptions;

public class GetSubscriptionsEndpoint : EndpointBaseAsync
  .WithRequest<GetSubscriptionsRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetSubscriptionsEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Fan))]
  [HttpGet(GetSubscriptionsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MembershipSubscriptionDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Dsquared Membership Subscriptions",
    Description = "Client Get Dsquared Membership Subscriptions",
    OperationId = "Client.GetDsquaredMembershipSubscriptions",
    Tags = new[] { "Dsquared Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetSubscriptionsRequest request, CancellationToken cancellationToken = new CancellationToken())
  {
    var ev = new GetSubscriptionsEvent(request.Lang ?? Languages.Ar);
    return await _mediator.Send(ev, cancellationToken);
  }
}
