using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Referee.Edit.Events;

public record EditRefereeEvent(int RefereeId, int? NationalityId, int? RegionId, string? Name, string? NameAr) : IRequest<ActionResult>;
