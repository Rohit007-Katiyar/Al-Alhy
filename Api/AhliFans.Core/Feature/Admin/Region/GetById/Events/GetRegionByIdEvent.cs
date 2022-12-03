using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Region.GetById.Events;

public record GetRegionByIdEvent(int RegionId,string Lang):IRequest<ActionResult>;
