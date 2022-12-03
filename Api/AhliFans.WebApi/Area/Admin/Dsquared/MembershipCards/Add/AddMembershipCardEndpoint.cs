using AhliFans.Core;
using AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Dsquared.MembershipCards;

public class AddMembershipCardEndpoint : EndpointBaseAsync
.WithRequest<AddMembershipCardRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public AddMembershipCardEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpPost(AddMembershipCardRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
      Summary = "Admin Add Subscription Card",
      Description = "Admin Add Subscription Card",
      OperationId = "Admin.AddMembershipCard",
      Tags = new[] { "Dsquared Endpoints" })
    ]
  public override async Task<ActionResult> HandleAsync([FromBody] AddMembershipCardRequest request, CancellationToken cancellationToken = default)
  {
    var ev = new AddMembershipCardEvent(request.Price, request.Description, request.DescriptionAr, request.Type, request.TypeAr, request.Months);
    return await _mediator.Send(ev, cancellationToken);
  }
}
