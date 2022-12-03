using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.GetById.Events;

public record GetTrophyById(int TrophyId,string Lang):IRequest<ActionResult>;
