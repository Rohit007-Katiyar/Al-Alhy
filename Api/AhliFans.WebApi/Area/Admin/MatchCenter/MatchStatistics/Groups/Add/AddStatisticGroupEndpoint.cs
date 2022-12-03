using AhliFans.Core;
using AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Groups;

public class AddStatisticGroupEndpoint : EndpointBaseAsync
.WithRequest<AddStatisticGroupRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public AddStatisticGroupEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpPost(AddStatisticGroupRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
  Summary = "Admin Add Match Statistic Group",
  Description = "Admin Add Match Statistic Group",
  OperationId = "Admin.AddMatchStatisticGroup",
  Tags = new[] { "Match Center Endpoints" })
]
  public override async Task<ActionResult> HandleAsync(AddStatisticGroupRequest request, CancellationToken cancellationToken = default)
  {
    var addEvent = new AddStatisticsGroupEvent(request.Name, request.NameAr, request.IsEnabled);
    return await _mediator.Send(addEvent, cancellationToken);
  }
}
