using AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.GetById.DTO;
using AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach.SocialMediaAccounts.GetById;

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
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CoachAccountDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Coach Account By Id",
    Description = "Admin Get Coach Account By Id",
    OperationId = "Admin.GetCoachAccount",
    Tags = new[] { "Coach Social Media Accounts Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAccountByIdEvent(request.AccountId), cancellationToken);
}
