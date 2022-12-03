using AhliFans.Core;
using AhliFans.Core.Feature.Fan.Match.GetById.DTO;
using AhliFans.Core.Feature.Fan.Match.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Match.GetById;

public class GetMatchByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetMatchByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MatchDetailsDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [SwaggerOperation(
  Summary = "Client get match details",
  Description = "Client get match details by id",
  OperationId = "Client.MatchById",
  Tags = new[] { "Match Endpoints" })
]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetByIdRequest request, CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(new GetMatchByIdEvent(request.MatchId, request.Language), cancellationToken);
  }
}
