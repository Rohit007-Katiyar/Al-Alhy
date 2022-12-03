using AhliFans.Core.Feature.Admin.Trophy.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Trophy.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Trophy;

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
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<TrophiesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin GetAll Trophies",
    Description = "Admin GetAll Trophies",
    OperationId = "Admin.GetAllTrophies",
    Tags = new[] { "Trophy Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllTrophyEvent(request.PageIndex, request.PageSize, request.TrophyTypeId, request.Name,request.IsAvailable,request.IsDeleted,request.Lang),
      cancellationToken);
}
