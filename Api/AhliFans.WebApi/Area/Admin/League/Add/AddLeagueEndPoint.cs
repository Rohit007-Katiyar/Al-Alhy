using AhliFans.Core.Feature.Admin.League.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.League;

public class AddLeagueEndPoint : EndpointBaseAsync
  .WithRequest<AddLeagueRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddLeagueEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddLeagueRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add League",
    Description = "Admin Add League",
    OperationId = "Admin.AddLeague",
    Tags = new[] {"League Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddLeagueRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddLeagueEvent(request.Name, request.NameAr, request.LeagueDateTimes), cancellationToken);
}
