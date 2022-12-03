using AhliFans.Core.Feature.Admin.Stadium.GetById.DTO;
using AhliFans.Core.Feature.Admin.Stadium.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Stadium;

public class GetStadiumEndPoint : EndpointBaseAsync
  .WithRequest<GetStadiumByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetStadiumEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetStadiumByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StadiumDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Stadium By Id",
    Description = "Admin Get Stadium By Id",
    OperationId = "Admin.GetByIdStadium",
    Tags = new[] {"Stadium Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetStadiumByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetStadiumByIdEvent(request.StadiumId,request.Lang),cancellationToken);
}
