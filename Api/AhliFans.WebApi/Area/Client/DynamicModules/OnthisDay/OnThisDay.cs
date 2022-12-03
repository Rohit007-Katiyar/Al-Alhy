using System.Web;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.DTO;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.DynamicModules.OnthisDay
{
    public class OnThisDay : Controller
    {
        private readonly IMediator _mediator;

        public OnThisDay(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet(RoutesConfig.ClientGetAllOnThisDayDynamicModules)]
        [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<GetAllDynamicModules>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GetAllDynamicModules))]
        [SwaggerOperation(
          Summary = "Dynamic Get All On This Day",
          Description = "Dynamic Get All On This Day",
          OperationId = "Admin.GetAllDynamicModules",
          Tags = new[] { "Dynamic Modules Endpoints" })
        ]
        public async Task<ActionResult> Get([FromQuery] DTO.GetAllDynamicModules request, CancellationToken cancellationToken = default)
        {
            request.Type = (int)Areas.Client;
            return await _mediator.Send(request, cancellationToken);
        }
    }
}
