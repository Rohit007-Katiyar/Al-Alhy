using AhliFans.Core.Feature.Admin.Team.TeamType.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Team.TeamType.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Team.TeamType;

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
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<TeamTypesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Team Type",
    Description = "Admin Get All Team Type",
    OperationId = "Admin.GetAllTeamType",
    Tags = new[] {"Team Type Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllRequest request, CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllTeamTypesEvent(request.Lang,request.IsDeleted), cancellationToken);
}
