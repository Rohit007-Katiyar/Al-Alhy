using AhliFans.Core;
using AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Dsquared.MembershipCards;

public class GetAllMembershipCardsEndpoint : EndpointBaseAsync
.WithRequest<GetAllMembershipCardsRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllMembershipCardsEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpGet(GetAllMembershipCardsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MembershipCardDto>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
        Summary = "Admin Get All Subscription Cards",
        Description = "Admin Get All Subscription Cards",
        OperationId = "Admin.GetAllMembershipCards",
        Tags = new[] { "Dsquared Endpoints" })
      ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllMembershipCardsRequest request, CancellationToken cancellationToken = default)
  {
    var ev = new GetAllMembershipCardsEvent(request.IsEnabled, request.PageIndex, request.PageSize, request.Lang ?? Languages.Ar);
    return await _mediator.Send(ev, cancellationToken);
  }
}
