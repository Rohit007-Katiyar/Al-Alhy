using AhliFans.Core.Feature.Admin.Season.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Season;

public class EditEndPoint : EndpointBaseAsync
  .WithRequest<EditRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Season",
    Description = "Admin Edit Season",
    OperationId = "Admin.EditSeason",
    Tags = new[] {"Season Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] EditRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(
      new EditSeasonEvent(request.SeasonId, request.Name, request.NameAr, request.StartDate, request.EndDate),
      cancellationToken);
}
