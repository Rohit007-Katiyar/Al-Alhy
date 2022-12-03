using AhliFans.Core.Feature.Admin.Region.GetById.DTO;
using AhliFans.Core.Feature.Admin.Region.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Region.GetById;

public class GetRegionByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetRegionByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetRegionByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetRegionByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegionDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Region By Id",
    Description = "Admin Get Region By Id",
    OperationId = "Admin.GetRegionById",
    Tags = new[] {"Region Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetRegionByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetRegionByIdEvent(request.RegionId, request.Lang), cancellationToken);
}
