using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.TrophyType.Add.Events;

public record AddTrophyTypeEvent(string Name,string NameAr):IRequest<ActionResult>;
