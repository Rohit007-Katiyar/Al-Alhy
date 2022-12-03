using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Account.AppLanguage.Change;
public record ChangeLanguageRequest(Language Language)
{
  public const string Route = $"{nameof(Areas.Client)}/Account/Language";
}
