using AhliFans.Core.Feature.Fan.MatchCenter.Coach.GetAll.DTO;
using AhliFans.Core.Feature.Fan.MatchCenter.Coach.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.MatchCenter.Coach.GetAll;

public class GetAllCoachesEndPoint : EndpointBaseAsync
  .WithRequest<GetAllCoachesRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllCoachesEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [AllowAnonymous]
  [HttpGet(GetAllCoachesRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<AllCurrentCoachesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Fan get all current coaches of match center",
    Description = "Fan get all current coaches of match center",
    OperationId = "Client.GetCurrentCoaches",
    Tags = new[] { "Coach Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllCoachesRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllCurrentCoachesEvent(request.Lang), cancellationToken);

}
