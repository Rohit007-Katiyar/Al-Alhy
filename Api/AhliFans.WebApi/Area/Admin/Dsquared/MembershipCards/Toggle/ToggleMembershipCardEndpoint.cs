using AhliFans.Core;
using AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Dsquared.MembershipCards;

public class ToggleMembershipCardEndpoint : EndpointBaseAsync
.WithRequest<ToggleMembershipCardRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public ToggleMembershipCardEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpPatch(ToggleMembershipCardRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
        Summary = "Admin Disable/Enable Subscription Card",
        Description = "Admin Disable/Enable Subscription Card",
        OperationId = "Admin.ToggleMembershipCard",
        Tags = new[] { "Dsquared Endpoints" })
    ]
  public override async Task<ActionResult> HandleAsync([FromRoute] ToggleMembershipCardRequest request, CancellationToken cancellationToken = default)
  {
    var ev = new ToggleMembershipCardEvent(request.CardId);
    return await _mediator.Send(ev, cancellationToken);
  }
}
