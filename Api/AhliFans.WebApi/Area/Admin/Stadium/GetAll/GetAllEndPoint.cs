using AhliFans.Core.Feature.Admin.Stadium.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Stadium.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Stadium;

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
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<GetAllStadiumsDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Stadiums",
    Description = "Admin Get All Stadiums",
    OperationId = "Admin.GetAllStadiums",
    Tags = new[] { "Stadium Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllRequest request,CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllStadiumsEvent(request.Lang,request.PageIndex,request.PageSize,request.IsDeleted),cancellationToken);
}
