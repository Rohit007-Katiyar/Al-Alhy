using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Referee.Add.Events;

public record AddRefereeEvent(int NationalityId, int RegionId, string Name, string NameAr) : IRequest<ActionResult>;
