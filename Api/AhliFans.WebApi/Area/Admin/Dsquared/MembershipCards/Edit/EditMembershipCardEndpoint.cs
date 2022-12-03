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

public class EditMembershipCardEndpoint : EndpointBaseAsync
.WithRequest<EditMembershipCardRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public EditMembershipCardEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpPut(EditMembershipCardRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
        Summary = "Admin Edit Subscription Card By Id",
        Description = "Admin Edit Subscription Card By Id",
        OperationId = "Admin.EditMembershipCard",
        Tags = new[] { "Dsquared Endpoints" })
      ]
  public override async Task<ActionResult> HandleAsync(EditMembershipCardRequest request, CancellationToken cancellationToken = default)
  {
    var ev = new EditMembershipCardEvent(request.Id, request.Description, request.DescriptionAr, request.Type,
      request.TypeAr, request.Price, request.Months);
    return await _mediator.Send(ev, cancellationToken);
  }
}
