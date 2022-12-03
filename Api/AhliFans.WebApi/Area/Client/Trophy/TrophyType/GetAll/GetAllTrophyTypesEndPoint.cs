using AhliFans.Core.Feature.Fan.Trophy.TrophyType.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Trophy.TrophyType.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Trophy;

public class GetAllTrophyTypesEndPoint : EndpointBaseAsync
  .WithRequest<GetAllTrophyTypesRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllTrophyTypesEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetAllTrophyTypesRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<FanTrophyTypesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get All Trophy Types",
    Description = "Client Get All Trophy Types",
    OperationId = "Client.GetAllTrophyTypes",
    Tags = new[] {"Trophy Type Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllTrophyTypesRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllTrophyTypesEvent(request.Name, request.Lang), cancellationToken);
}
