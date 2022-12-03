using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Coach.SocialMediaAccounts.GetAll.Events;

public record GetAllCoachAccountsEvent(int CoachId):IRequest<ActionResult>;
