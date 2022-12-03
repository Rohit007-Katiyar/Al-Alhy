using AhliFans.Core.Feature.Fan.Preferences.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.FanPreferences;

public class AddPreferencesEndPoint : EndpointBaseAsync
  .WithRequest<AddPreferencesRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddPreferencesEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddPreferencesRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Add Preferences",
    Description = "Client Add Preferences",
    OperationId = "Client.AddPreferences",
    Tags = new[] {"Fan Preferences Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddPreferencesRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddPreferencesEvent(request.PlayerId, request.LocalTrophyId, request.FavoritePlayerAllTime,request.FavoriteCoachAllTime,request.AfricanTrophyId,
        request.MatchId,request.FavoriteMoment), cancellationToken);
}
