using AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.GetById.DTO;
using AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Player.SocialMediaAccounts.GetById;

public class GetByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerAccountDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Player Account By Id",
    Description = "Admin Get Player Account By Id",
    OperationId = "Admin.GetPlayerAccount",
    Tags = new[] {"Player Social Media Accounts Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAccountByIdEvent(request.AccountId), cancellationToken);
}
