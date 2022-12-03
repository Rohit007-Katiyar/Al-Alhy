using AhliFans.Core.Feature.Admin.Player.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Player;

public class AddEndPoint : EndpointBaseAsync
  .WithRequest<AddRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPost(AddRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Player",
    Description = "Admin Add Player",
    OperationId = "Admin.AddPlayer",
    Tags = new[] { "Player Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] AddRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddPlayerEvent(request.PositionId, request.Number, request.Name, request.NameAr, request.BirthDate, request.Height, request.Weight,
      request.CityOfBirth, request.Biography, request.BiographyAr, request.Pic, request.DateSigned, request.CountryHeLive, request.TeamCategoryId,request.FaceBookAccount,
      request.InstaAccount,request.TwitterAccount), cancellationToken);
}
