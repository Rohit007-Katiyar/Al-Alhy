using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Jersey.GetAll.Events;
public record GetAllJerseysEvent(int PageIndex, int PageSize, bool IsEnabled,bool IsHome, string ImagePathUrl) : IRequest<ActionResult>;
