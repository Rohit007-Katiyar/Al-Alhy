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

public class GetMembershipCardByIdEndpoint : EndpointBaseAsync
  .WithRequest<GetMembershipCardByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetMembershipCardByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Fan))]
  [HttpGet(GetMembershipCardByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MembershipCardDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Dsquared Subscription Card By Id",
    Description = "Client Get Dsquared Subscription Card By Id",
    OperationId = "Client.GetDsquaredMembershipCardById",
    Tags = new[] { "Dsquared Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute]GetMembershipCardByIdRequest request, CancellationToken cancellationToken = new CancellationToken())
  {
    var ev = new GetMembershipCardByIdEvent(request.CardId, request.Lang ?? Languages.Ar);
    return await _mediator.Send(ev, cancellationToken);
  }
}
