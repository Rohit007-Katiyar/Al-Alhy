using Newtonsoft.Json;

namespace AhliFans.SharedKernel.APIServices.Cequens.Settings;

public class CequensSettings
{
  [JsonProperty("apiKey")] public string ApiKey { get; set; } = string.Empty;

  [JsonProperty("userName")] public string UserName { get; set; } = string.Empty;
}
