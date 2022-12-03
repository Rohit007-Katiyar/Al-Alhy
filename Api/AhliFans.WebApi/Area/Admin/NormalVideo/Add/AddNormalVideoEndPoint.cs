using System.Security.Claims;
using AhliFans.Core.Feature.Admin.NormalVideo.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace AhliFans.WebApi.Area.Admin.NormalVideo.Add;

public class AddNormalVideoEndPoint : EndpointBaseAsync
  .WithRequest<AddNormalVideoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;
  public AddNormalVideoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddNormalVideoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add NormalVideo",
    Description = "Admin Add NormalVideo",
    OperationId = "Admin.NormalVideo",
    Tags = new[] { "NormalVideo Endpoints" })
  ]

  public override async Task<ActionResult> HandleAsync([FromForm] AddNormalVideoRequest request, CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(new AddNormalVideoEvent(request.SeasonId, request.Month, request.VideoURL, request.MatchId, request.LeagueId,
        request.Description, request.DescriptionAr, request.PlayerId, request.CoachId, request.CategoryId, User.FindFirstValue("User Id")), cancellationToken);
  }

}
