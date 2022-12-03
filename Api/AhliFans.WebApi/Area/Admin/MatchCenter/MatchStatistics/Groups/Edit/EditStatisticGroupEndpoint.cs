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

public class EditStatisticGroupEndpoint : EndpointBaseAsync
.WithRequest<EditStatisticGroupRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public EditStatisticGroupEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpPut(EditStatisticGroupRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
  Summary = "Admin Edit Match Statistic Group",
  Description = "Admin Edit Match Statistic Group",
  OperationId = "Admin.EditMatchStatisticGroup",
  Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(EditStatisticGroupRequest request, CancellationToken cancellationToken = default)
  {
    var editEvent = new EditStatisticGroupEvent(request.Id, request.Name, request.NameAr, request.IsEnabled);
    return await _mediator.Send(editEvent, cancellationToken);
  }
}
