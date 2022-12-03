using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Trophy.TrophyType.GetAll.Events;

public record GetAllTrophyTypesEvent(string? Name,string Lang):IRequest<ActionResult>;
