using AhliFans.Core;
using AhliFans.Core.Feature.Admin.SquadList.Get.Dto;
using AhliFans.Core.Feature.Admin.SquadList.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.SquadList;

public class GetSquadListEndPoint : EndpointBaseAsync
.WithRequest<GetSquadListRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetSquadListEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpGet(GetSquadListRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<SquadListPlayerDto>))]
  [SwaggerOperation(
    Summary = "Admin get match squad list",
    Description = "Admin get match squad list by match id",
    OperationId = "Admin.GetSquadListMember",
    Tags = new[] { "Squad List Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetSquadListRequest request, CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(new GetSquadListEvent(request.MatchId, request.Lang), cancellationToken);
  }
}
