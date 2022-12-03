using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.GetAll.Events;

public record GetAllCoachAccountsEvent(int CoachId, bool IsDeleted):IRequest<ActionResult>;
