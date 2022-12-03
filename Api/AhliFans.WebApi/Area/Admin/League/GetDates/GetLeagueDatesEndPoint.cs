using AhliFans.Core.Feature.Admin.League.GetDates.DTO;
using AhliFans.Core.Feature.Admin.League.GetDates.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.League;

public class GetLeagueDatesEndPoint : EndpointBaseAsync
  .WithRequest<GetDatesRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetLeagueDatesEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetDatesRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<LeagueDates>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All League Dates",
    Description = "Admin Get All League Dates",
    OperationId = "Admin.AllLeagueDates",
    Tags = new[] {"League Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetDatesRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetLeagueDateEvent(request.LeagueId), cancellationToken);
}
