using AhliFans.Core.Feature.Admin.Season.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Season;

public class AddSeasonEndPoint : EndpointBaseAsync
  .WithRequest<AddSeasonRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddSeasonEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPost(AddSeasonRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Season",
    Description = "Admin Add Season",
    OperationId = "Admin.AddSeason",
    Tags = new[] { "Season Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddSeasonRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddSeasonEvent(request.Name,request.NameAr,request.StartDate,request.EndDate),
      cancellationToken);
}
