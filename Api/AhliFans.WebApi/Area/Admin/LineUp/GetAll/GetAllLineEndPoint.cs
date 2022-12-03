using AhliFans.Core.Feature.Admin.LineUp.GetAll.DTO;
using AhliFans.Core.Feature.Admin.LineUp.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.LineUp;

public class GetAllLineEndPoint : EndpointBaseAsync
  .WithRequest<GetAllLineUpRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllLineEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetAllLineUpRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<LineUpsDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin get all LineUps",
    Description = "Admin get all LineUps",
    OperationId = "Admin.GetAllLineUp",
    Tags = new[] {"LineUp Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllLineUpRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllLineUpEvent(request.Lang,request.PageIndex, request.PageSize, request.Date, request.OpponentTeam),
      cancellationToken);
}
