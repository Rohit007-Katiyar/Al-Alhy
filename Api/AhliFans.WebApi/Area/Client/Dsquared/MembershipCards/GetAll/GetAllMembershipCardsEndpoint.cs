using AhliFans.Core;
using AhliFans.Core.Feature.Fan.Dsquared.MembershipCards;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Dsquared.MembershipCards;

public class GetAllMembershipCardsEndpoint : EndpointBaseAsync
  .WithRequest<GetAllMembershipCardsRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllMembershipCardsEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Fan))]
  [HttpGet(GetAllMembershipCardsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MembershipCardDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get All Dsquared Subscription Cards",
    Description = "Client Get All Dsquared Subscription Cards",
    OperationId = "Client.GetAllDsquaredMembershipCards",
    Tags = new[] { "Dsquared Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllMembershipCardsRequest request, CancellationToken cancellationToken = new CancellationToken())
  {
    var ev = new GetAllMembershipCardsEvent(request.PageIndex, request.PageSize, request.Lang ?? Languages.Ar);
    return await _mediator.Send(ev, cancellationToken);
  }
}
