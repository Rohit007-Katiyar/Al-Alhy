using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.Edit.Events;

public record EditCoachAccountEvent(int CoachId, string? FaceBookAccount, string? InstaAccount, string? TwitterAccount):IRequest<ActionResult>;
