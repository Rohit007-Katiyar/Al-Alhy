using AhliFans.SharedKernel.APIServices.FaceBook.IRepository;
using AhliFans.SharedKernel.APIServices.FaceBook.Model;
using AhliFans.SharedKernel.APIServices.FaceBook.Settings;
using Newtonsoft.Json;

namespace AhliFans.SharedKernel.APIServices.FaceBook.Repository;

public class FaceBookAuthService :  IFaceBookAuthService
{
  private readonly FaceBookAuthSettings _authSettings;
  private readonly IHttpClientFactory _httpClientFactory;
  private const string TokenValidationUrl= "https://graph.facebook.com/debug_token?input_token={0}&access_token={1}|{2}"; //Where {0} is the access token ,{1} is App Id and {2} is app secret
  private const string UserInfoUrl= "https://graph.facebook.com/me?fields=first_name,last_name,picture,email&access_token={0}";

  public FaceBookAuthService(FaceBookAuthSettings authSettings,IHttpClientFactory httpClientFactory)
  {
    _authSettings = authSettings;
    _httpClientFactory = httpClientFactory;
  }

  public async Task<FaceBookTokenValidation> ValidationAccessToken(string accessToken)
  {
    var formattedUrl = string.Format(TokenValidationUrl, accessToken, _authSettings.AppId, _authSettings.AppSecret);

    var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);
    result.EnsureSuccessStatusCode();
    
    var responseString = await result.Content.ReadAsStringAsync();
    return JsonConvert.DeserializeObject<FaceBookTokenValidation>(responseString)!;
  }

  public async Task<FaceBookUserInfo> GetUserInfo(string accessToken)
  {
    var formattedUrl = string.Format(UserInfoUrl, accessToken);

    var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);
    result.EnsureSuccessStatusCode();

    var responseString = await result.Content.ReadAsStringAsync();
    return JsonConvert.DeserializeObject<FaceBookUserInfo>(responseString)!;
  }
}
