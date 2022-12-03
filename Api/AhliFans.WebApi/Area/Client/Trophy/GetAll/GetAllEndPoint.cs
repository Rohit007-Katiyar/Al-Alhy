using AhliFans.Core.Feature.Fan.Trophy.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Trophy.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Trophy.GetAll;

public class GetAllEndPoint : EndpointBaseAsync
  .WithRequest<GetAllRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [AllowAnonymous]
  [HttpGet(GetAllRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<FanTrophiesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client GetAll Trophies",
    Description = "Client GetAll Trophies",
    OperationId = "Client.GetAllTrophies",
    Tags = new[] { "Trophy Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllTrophyEvent(request.PageIndex, request.PageSize, request.TrophyTypeId, request.Name,request.Lang),
      cancellationToken);
}
