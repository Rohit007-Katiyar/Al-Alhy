using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Region.ChangeStatus.Events;

public record ChangeRegionStatusEvent(int RegionId) :IRequest<ActionResult>;
