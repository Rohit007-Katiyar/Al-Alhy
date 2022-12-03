using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Stadium.Add.Events;

public record AddStadiumEvent(string Name, string NameAr, int RegionId, string Location) :IRequest<ActionResult>;
