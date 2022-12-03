using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.Edit.Events;

public record EditPlayerAccountEvent(int PlayerId, string? FaceBookAccount, string? InstaAccount, string? TwitterAccount) :IRequest<ActionResult>;
