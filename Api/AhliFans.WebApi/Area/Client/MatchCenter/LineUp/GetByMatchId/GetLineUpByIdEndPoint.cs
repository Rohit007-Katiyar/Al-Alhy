using AhliFans.Core.Feature.Fan.LineUp.GetByMatchId.DTO;
using AhliFans.Core.Feature.Fan.LineUp.GetByMatchId.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.MatchCenter;

public class GetLineUpByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetLineUpByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<LineUpDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Fan get LineUp By Id",
    Description = "Fan get LineUp By Id",
    OperationId = "Client.GetLineUp",
    Tags = new[] { "LineUp Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetLineUpByIdEvent(request.MatchId, request.Lang,request.IsSubstitution), cancellationToken);
}
