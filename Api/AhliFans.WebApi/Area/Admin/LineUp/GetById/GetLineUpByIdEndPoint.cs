using AhliFans.Core.Feature.Admin.LineUp.GetById.DTO;
using AhliFans.Core.Feature.Admin.LineUp.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.LineUp;

public class GetLineUpByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetLineUpByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LineUpDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin get LineUp By Id",
    Description = "Admin get LineUp By Id",
    OperationId = "Admin.GetLineUp",
    Tags = new[] {"LineUp Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetLineUpByIdEvent(request.MatchId, request.Lang), cancellationToken);
}
