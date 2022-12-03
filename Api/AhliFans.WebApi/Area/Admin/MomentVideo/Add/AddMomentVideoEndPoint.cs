using System.Security.Claims;
using AhliFans.Core.Feature.Admin.MomentVideo.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace AhliFans.WebApi.Area.Admin.MomentVideo.Add;

public class AddMomentVideoEndPoint : EndpointBaseAsync
  .WithRequest<AddMomentVideoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;
  public AddMomentVideoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddMomentVideoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add MomentVideo",
    Description = "Admin Add MomentVideo",
    OperationId = "Admin.MomentVideo",
    Tags = new[] { "MomentVideo Endpoints" })
  ]

  public override async Task<ActionResult> HandleAsync([FromForm] AddMomentVideoRequest request, CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddMomentVideoEvent(request.SeasonId, request.Month, request.VideoURL, request.MatchId, request.LeagueId,
        request.Description, request.DescriptionAr, request.PlayerId, request.VideoType, request.Time, request.CategoryId, User.FindFirstValue("User Id")), cancellationToken);
}
