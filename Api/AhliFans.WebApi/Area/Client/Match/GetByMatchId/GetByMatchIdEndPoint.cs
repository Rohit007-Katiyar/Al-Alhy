using AhliFans.Core.Feature.Fan.Match.GetByMatchId.DTO;
using AhliFans.Core.Feature.Fan.Match.GetByMatchId.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.DTO;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Match.GetByMatchId;
public class GetByMatchIdEndPoint : EndpointBaseAsync
.WithRequest<GetByMatchIdRequest>
.WithActionResult
{
    private readonly IMediator _mediator;

    public GetByMatchIdEndPoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[AllowAnonymous]
    [HttpGet(GetByMatchIdRequest.Route)]
    [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MatchCenterViewModel))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(
    Summary = "Client get match details",
    Description = "Client get match details by id",
    OperationId = "Client.MatchById",
    Tags = new[] { "Match Endpoints" })
  ]
    public override async Task<ActionResult> HandleAsync([FromQuery] GetByMatchIdRequest request, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetMatchByIdEvents(request.MatchId, request.Language), cancellationToken);
    }
}