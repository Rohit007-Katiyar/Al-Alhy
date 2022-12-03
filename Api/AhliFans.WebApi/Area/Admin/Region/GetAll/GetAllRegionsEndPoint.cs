using AhliFans.Core.Feature.Admin.Region.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Region.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Region;

public class GetAllRegionsEndPoint : EndpointBaseAsync
  .WithRequest<GetAllRegionsRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllRegionsEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetAllRegionsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<RegionsDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Regions",
    Description = "Admin Get All Regions",
    OperationId = "Admin.AllRegions",
    Tags = new[] {"Region Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllRegionsRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllRegionsEvent(request.PageIndex,request.PageSize,request.Name, request.Lang,request.IsDeleted),cancellationToken);
}
