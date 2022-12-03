using System.Security.Claims;
using AhliFans.Core.Feature.Admin.Category.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Category.Edit;
public class EditCategoryEndPoint : EndpointBaseAsync
  .WithRequest<EditCategoryRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;
  public EditCategoryEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditCategoryRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Update Category",
    Description = "Admin Update Category",
    OperationId = "Admin.UpdateCategory",
    Tags = new[] { "Category Endpoints" })
  ]
  public async override Task<ActionResult> HandleAsync([FromForm] EditCategoryRequest request, CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(new EditCategoryEvent(request.CategoryId, request.Name, request.NameAr, request.Description, request.DescriptionAr, 
      request.photo,
      request.video,
      request.otd,
      User.FindFirstValue("User Id")), cancellationToken);
  }
}
