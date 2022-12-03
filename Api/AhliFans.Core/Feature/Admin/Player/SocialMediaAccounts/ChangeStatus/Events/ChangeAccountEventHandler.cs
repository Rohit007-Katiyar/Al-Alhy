using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.ChangeStatus.Events;

public class ChangeAccountEventHandler : IRequestHandler<ChangeAccountStatusEvent,ActionResult>
{
  private readonly IRepository<SocialMediaAccount> _accountRepository;

  public ChangeAccountEventHandler(IRepository<SocialMediaAccount> accountRepository)
  {
    _accountRepository = accountRepository;
  }
  public async Task<ActionResult> Handle(ChangeAccountStatusEvent request, CancellationToken cancellationToken)
  {
    var account = await _accountRepository.GetByIdAsync(request.AccountId, cancellationToken);
    if (account is null) return new NotFoundObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    account.IsDeleted = !account.IsDeleted;
    await _accountRepository.UpdateAsync(account, cancellationToken);
    await _accountRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(account.IsDeleted ? "Delete Account Done You Can Retrieve It Any Time" : "Retrieve Account Done You Can Delete It Any Time", ResponseStatus.Success));
  }
}
