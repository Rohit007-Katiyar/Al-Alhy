#nullable disable
using Newtonsoft.Json;

namespace AhliFans.SharedKernel.APIServices.FaceBook.Model;

public class FaceBookTokenValidation
{
  [JsonProperty("data")]
  public TokenValidationData ValidationData{get; set;}
}

public class TokenValidationData
{
    [JsonProperty("app_id")]
    public string Appid{get; set;}

    [JsonProperty("type")]
    public string Type{get; set;}

    [JsonProperty("application")]
    public string Application{get; set; }

    [JsonProperty("data_access_expires_at")]
    public long DataAccessExpiresAt{get; set; }

    [JsonProperty("expires_at")]
    public long Expiresat{get; set;}

    [JsonProperty("is_valid")]
    public bool Isvalid{get; set;}

    [JsonProperty("scopes")]
    public string[] Scopes{get; set;}

    [JsonProperty("user_id")]
    public string UserId{get; set;}
}
