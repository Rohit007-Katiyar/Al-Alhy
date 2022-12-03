using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.Add.Events;

public record AddCoachAccountsEvent(int CoachId, string? FaceBookAccount, string? InstaAccount, string? TwitterAccount) :IRequest<ActionResult>;
