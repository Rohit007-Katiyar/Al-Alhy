using AhliFans.Core.Feature.Admin.Season.GetById.DTO;
using AhliFans.Core.Feature.Admin.Season.GetById.Event;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Season;

public class GetByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeasonDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get By Id Season",
    Description = "Admin Get By Id Season",
    OperationId = "Admin.GetByIdSeason",
    Tags = new[] {"Season Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetSeasonByIdEvent(request.SeasonId, request.Lang), cancellationToken);
}
