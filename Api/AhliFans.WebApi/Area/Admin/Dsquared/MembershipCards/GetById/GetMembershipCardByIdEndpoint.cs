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

public class GetMembershipCardByIdEndpoint : EndpointBaseAsync
.WithRequest<GetMembershipCardByIdRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetMembershipCardByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpGet(GetMembershipCardByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MembershipCardDetailsDto))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
          Summary = "Admin Get Subscription Card By Id",
          Description = "Admin Get Subscription Card By Id",
          OperationId = "Admin.GetMembershipCardById",
          Tags = new[] { "Dsquared Endpoints" })
    ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetMembershipCardByIdRequest request, CancellationToken cancellationToken = default)
  {
    var ev = new GetMembershipCardByIdEvent(request.CardId);
    return await _mediator.Send(ev, cancellationToken);
  }
}
