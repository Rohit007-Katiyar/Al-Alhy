using AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.GetById.DTO;
using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.GetById.Events;

public class GetByIdEventHandler : IRequestHandler<GetAccountByIdEvent,ActionResult>
{
  private readonly IRepository<SocialMediaAccount> _accountRepository;

  public GetByIdEventHandler(IRepository<SocialMediaAccount> accountRepository)
  {
    _accountRepository = accountRepository;
  }
  public async Task<ActionResult> Handle(GetAccountByIdEvent request, CancellationToken cancellationToken)
  {
    var account = await _accountRepository.GetByIdAsync(request.AccountId, cancellationToken);
    if (account == null) return new NotFoundObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    return new OkObjectResult(new PlayerAccountDto(account.Id, account.SocialMediaAccount1,account.IsDeleted,(int)account.Type!));
  }
}
