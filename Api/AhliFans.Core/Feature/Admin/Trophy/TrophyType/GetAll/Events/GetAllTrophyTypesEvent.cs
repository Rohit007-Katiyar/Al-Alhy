using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.TrophyType.GetAll.Events;

public record GetAllTrophyTypesEvent(string Name,string Lang,bool IsDeleted):IRequest<ActionResult>;
