using AhliFans.Core.Feature.Fan.SquadList.Get.Dto;
using AhliFans.Core.Feature.Fan.SquadList.Get.Events;
using AhliFans.Core.Feature.Fan.SquadList.GetAll.Dto;
using AhliFans.Core.Feature.Security.Enums;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.MatchCenter;

public class GetSquadListEndpoint : EndpointBaseAsync
.WithRequest<GetSquadListRequest>
.WithActionResult
{
    private readonly IMediator _mediator;

    public GetSquadListEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet(GetSquadListRequest.Route)]
    [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<PlayerListsDtos>))]
    [SwaggerOperation(
      Summary = "Fan get match squad list",
      Description = "Fan get match squad list by match id",
      OperationId = "Client.GetSquadList",
      Tags = new[] { "Match SquadList Endpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery] GetSquadListRequest request, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetSquadListEvent(request.MatchId, request.Lang!, request.GeneralPosition), cancellationToken);
    }
}
