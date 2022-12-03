using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using AhliFans.SharedKernel.APIServices.Cequens.Enums;
using AhliFans.SharedKernel.APIServices.Cequens.IRepository;
using AhliFans.SharedKernel.APIServices.Cequens.Model;
using AhliFans.SharedKernel.APIServices.Cequens.Settings;
using Microsoft.Extensions.Options;

namespace AhliFans.SharedKernel.APIServices.Cequens.Repository;

public class CequensService : ICequensService
{
  private readonly HttpClient _httpClient;

  private const string OTPRoute = "https://apis.cequens.com/verify/v2/verifications";

  private const string Channel = "SMS";

  private readonly CequensSettings _settings;

  public CequensService(IHttpClientFactory httpClientFactory, IOptions<CequensSettings> settings)
  {
    _httpClient = httpClientFactory.CreateClient(nameof(CequensService));
    _settings = settings.Value;
  }

  public async Task<ISendOtpResult> SendOTPAsync(string mobileNumber)
  {
    var request = new SendOtpRequest();
    request.Channel = Channel;
    request.RecipientIdentifier = mobileNumber;

    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.ApiKey);
    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    var httpResponse = await _httpClient.PostAsJsonAsync(OTPRoute, request);
    if (httpResponse.IsSuccessStatusCode)
    {
      return (await httpResponse.Content.ReadFromJsonAsync<SendOtpResponse>())!;
    }
    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
    {
      var x = await httpResponse.Content.ReadAsStringAsync();
      return (await httpResponse.Content.ReadFromJsonAsync<SendOtpBadRequestResponse>())!;
    }
    var failure = new SendOTPFailure();
    return failure;
  }

  public async Task<OtpValidationState> ValidateOTPAsync(string otp, string checkCode)
  {
    var request = new ValidateOtpRequest
    {
      CheckCode = checkCode,
      OtpPasscode = otp
    };
    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.ApiKey);
    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    var httpResponse = await _httpClient.PutAsJsonAsync(OTPRoute, request);
    if (httpResponse.IsSuccessStatusCode)
    {
      var response = await httpResponse.Content.ReadFromJsonAsync<ValidateOtpResponse>();
      return (OtpValidationState)response!.Data.otpPasscodeStatus;
    }
    return OtpValidationState.Failure;
  }

  public async Task<OtpValidationState> CheckOTPStatusAsync(string checkCode)
  {
    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.ApiKey);
    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    var route = $"{OTPRoute}?checkCode={checkCode}";
    var httpResponse = await _httpClient.GetAsync(route);
    if (httpResponse.IsSuccessStatusCode)
    {
      var response = await httpResponse.Content.ReadFromJsonAsync<CheckOtpResponse>();
      var status = response!.Data.ChecksList.First(c => c.VerificationStatus == true).OtpStatus;
      return (OtpValidationState)status;
    }
    return OtpValidationState.Failure;
  }
}
