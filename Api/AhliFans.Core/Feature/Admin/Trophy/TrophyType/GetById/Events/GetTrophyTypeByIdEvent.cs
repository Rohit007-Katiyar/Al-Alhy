using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.TrophyType.GetById.Events;

public record GetTrophyTypeByIdEvent(int TrophyTypeId) : IRequest<ActionResult>;
