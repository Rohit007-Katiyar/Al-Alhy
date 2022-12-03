using AhliFans.Core.Feature.Fan.SquadList.Get.Dto;
using AhliFans.Core.Feature.Fan.SquadList.Get.Events;
using AhliFans.Core.Feature.Fan.SquadList.GetAll.Dto;
using AhliFans.Core.Feature.Fan.SquadList.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.MatchCenter.SquadList.GetAllSqaudList;

public class GetAllSquadListEndpoint : EndpointBaseAsync
.WithRequest<GetAllSquadListRequest>
.WithActionResult
{
    private readonly IMediator _mediator;

    public GetAllSquadListEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[AllowAnonymous]
    [HttpGet(GetAllSquadListRequest.Route)]
    [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<AllSquadListDto>))]
    [SwaggerOperation(
      Summary = "Fan get All squad list",
      Description = "Fan get match squad list",
      OperationId = "Client.GetAllSquadList",
      Tags = new[] { "Match SquadList Endpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery] GetAllSquadListRequest request, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetAllSquadListEvent(request.Lang!), cancellationToken);
    }
}
