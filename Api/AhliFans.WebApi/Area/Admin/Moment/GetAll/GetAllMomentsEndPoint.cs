using AhliFans.Core.Feature.Admin.Moment.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Moment.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Moment.GetAll;

public class GetAllMomentsEndPoint : EndpointBaseAsync
  .WithRequest<GetAllMomentsRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllMomentsEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetAllMomentsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MomentsDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Moments",
    Description = "Admin Get All Moments",
    OperationId = "Admin.GetAllMoment",
    Tags = new[] { "Moment Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllMomentsRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllMomentsEvent(request.Lang, request.PageIndex,request.PageSize,request.IsAvailable),
      cancellationToken);
}
