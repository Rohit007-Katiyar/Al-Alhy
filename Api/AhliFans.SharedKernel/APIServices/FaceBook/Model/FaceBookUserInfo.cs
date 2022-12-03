#nullable disable
using Newtonsoft.Json;

namespace AhliFans.SharedKernel.APIServices.FaceBook.Model;

public class FaceBookUserInfo
{
  [JsonProperty("first_name")]
  public string FirstName{get; set;}

  [JsonProperty("last_name")]
  public string LastName{get; set;}

  [JsonProperty("picture")]
  public Picture Picture{get; set;}

  [JsonProperty("email")]
  public string Email{get; set;}
}


public class Picture
{
  [JsonProperty("PictureData")]
  public PictureData PictureData { get; set;}
}
public class PictureData
{

  [JsonProperty("height")]
  public long Height{get; set;}

  [JsonProperty("is_silhouette")]
  public bool IsSilhouette{get; set;}

  [JsonProperty("url")]
  public Uri Uri{get; set;}

  [JsonProperty("width")]
  public long Width{get; set;}
}
