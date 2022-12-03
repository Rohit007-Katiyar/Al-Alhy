using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Player.SocialMediaAccounts.GetAll.Events;

public record GetAllPlayerAccountsEvent(int PlayerId):IRequest<ActionResult>;
