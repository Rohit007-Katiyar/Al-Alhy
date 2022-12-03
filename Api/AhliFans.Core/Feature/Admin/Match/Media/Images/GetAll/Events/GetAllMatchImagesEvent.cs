using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.Media.Images.GetAll.Events;

public record GetAllMatchImagesEvent(int MatchId,string ImageUrl) : IRequest<ActionResult>;
