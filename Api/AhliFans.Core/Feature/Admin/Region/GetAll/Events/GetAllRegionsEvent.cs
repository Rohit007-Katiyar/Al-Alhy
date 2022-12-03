using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Region.GetAll.Events;

public record GetAllRegionsEvent(int PageIndex,int PageSize,string Name,string Lang, bool IsDeleted) :IRequest<ActionResult>;
