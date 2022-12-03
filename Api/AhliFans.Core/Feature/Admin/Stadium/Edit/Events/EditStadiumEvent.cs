using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Stadium.Edit.Events;

public record EditStadiumEvent(int StadiumId, int? RegionId, string? Name, string? NameAr, string? Location) : IRequest<ActionResult>;
