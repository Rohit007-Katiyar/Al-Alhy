﻿using AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.Edit.Specification;
using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.Edit.Events;

public class EditPlayerAccountEventHandler : IRequestHandler<EditPlayerAccountEvent,ActionResult>
{
  private readonly IRepository<SocialMediaAccount> _accountRepository;

  public EditPlayerAccountEventHandler(IRepository<SocialMediaAccount> accountRepository)
  {
    _accountRepository = accountRepository;
  }
  public async Task<ActionResult> Handle(EditPlayerAccountEvent request, CancellationToken cancellationToken)
  {
    var accounts = await _accountRepository.ListAsync(new GetPlayerAccounts(request.PlayerId), cancellationToken);
    if (accounts.Count == 0) return new OkObjectResult(Enumerable.Empty<string>());

    foreach (var account in accounts)
    {
      if (account.Type == SocialMediaTypes.FaceBook)
      {
        account.SocialMediaAccount1 = request.FaceBookAccount;

        await _accountRepository.UpdateAsync(account, cancellationToken);
        await _accountRepository.SaveChangesAsync(cancellationToken);
      }
      if (account.Type == SocialMediaTypes.Instagram)
      {
        account.SocialMediaAccount1 = request.InstaAccount;

        await _accountRepository.UpdateAsync(account, cancellationToken);
        await _accountRepository.SaveChangesAsync(cancellationToken);
      }
      if (account.Type == SocialMediaTypes.Twitter)
      {
        account.SocialMediaAccount1 = request.TwitterAccount;

        await _accountRepository.UpdateAsync(account, cancellationToken);
        await _accountRepository.SaveChangesAsync(cancellationToken);
      }
    }
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
