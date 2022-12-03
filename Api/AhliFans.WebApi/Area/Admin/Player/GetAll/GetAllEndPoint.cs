using System.Web;
using AhliFans.Core.Feature.Admin.Player.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Player.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Player;

public class GetAllEndPoint : EndpointBaseAsync
  .WithRequest<GetAllRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetAllRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<PlayersDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Players",
    Description = "Admin Get All Players",
    OperationId = "Admin.AllPlayers",
    Tags = new[] { "Player Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllRequest request,
    CancellationToken cancellationToken = default)
  {
    var decodedName = HttpUtility.UrlDecode(request.PlayerName);
    return await _mediator.Send(new GetAllPlayersEvent(request.PageIndex, request.PageSize, decodedName!,
      request.Lang, request.IsDeleted), cancellationToken);
  }

}
