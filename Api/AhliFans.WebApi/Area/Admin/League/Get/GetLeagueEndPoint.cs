using AhliFans.Core.Feature.Admin.League.Get.DTO;
using AhliFans.Core.Feature.Admin.League.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.League;

public class GetLeagueEndPoint : EndpointBaseAsync
  .WithRequest<GetLeagueRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetLeagueEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetLeagueRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<LeaguesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Leagues",
    Description = "Admin Get All Leagues",
    OperationId = "Admin.AllLeague",
    Tags = new[] {"League Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetLeagueRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetLeagueEvent(request.LeagueId, request.LeagueName,request.Lang,request.IsDeleted), cancellationToken);
}
