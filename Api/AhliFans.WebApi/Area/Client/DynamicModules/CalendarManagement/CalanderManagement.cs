using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.DTO;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Web;

namespace AhliFans.WebApi.Area.Client.DynamicModules.CalendarManagement
{
    public class CalanderManagement : EndpointBaseAsync.WithRequest<GetAllDynamicModules>.WithActionResult
    {
        private readonly IMediator _mediator;

        public CalanderManagement(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet(RoutesConfig.ClientGetAllCalanderDayDynamicModules)]
        [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<GetAllDynamicModules>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GetAllDynamicModules))]
        [SwaggerOperation(
          Summary = "Dynamic Get All Calander Management",
          Description = "Dynamic Get All Calander Management",
          OperationId = "Admin.GetAllDynamicModules",
          Tags = new[] { "Dynamic Modules Endpoints" })
        ]
        public override async Task<ActionResult> HandleAsync([FromQuery] GetAllDynamicModules request,
         CancellationToken cancellationToken = default)
        {
            var decodedWord = HttpUtility.UrlDecode(request.SearchWord);
            return await _mediator.Send(request, cancellationToken);
        }
    }
}
