using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Location.Countries.Events;

public record GetAllCountriesEvent(string? Name, string Lang) : IRequest<ActionResult>;
