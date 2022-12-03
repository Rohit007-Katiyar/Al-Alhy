using AhliFans.Core.Feature.Fan.Preferences.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.FanPreferences;

public class EditPreferencesEndPoint : EndpointBaseAsync
  .WithRequest<EditPreferencesRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditPreferencesEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditPreferencesRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Edit Preferences",
    Description = "Client Edit Preferences",
    OperationId = "Client.EditPreferences",
    Tags = new[] {"Fan Preferences Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] EditPreferencesRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditPreferencesEvent(request.PlayerId, request.LocalTrophyId,
      request.FavoritePlayerAllTime, request.FavoriteCoachAllTime, request.AfricanTrophyId, request.MatchId,
      request.FavoriteMoment),cancellationToken);
}
