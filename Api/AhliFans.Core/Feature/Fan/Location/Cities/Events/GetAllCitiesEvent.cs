using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Location.Cities.Events;

public record GetAllCitiesEvent(int CountryId,string Lang,string? Name):IRequest<ActionResult>;
