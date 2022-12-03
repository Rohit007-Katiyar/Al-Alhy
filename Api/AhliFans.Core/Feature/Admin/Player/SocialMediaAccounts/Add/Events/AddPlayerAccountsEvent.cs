using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.Add.Events;

public record AddPlayerAccountsEvent(int PlayerId, string? FaceBookAccount, string? InstaAccount, string? TwitterAccount) :IRequest<ActionResult>;
