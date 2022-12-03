using System.Net.Http.Json;
using System.Text;
using AhliFans.SharedKernel.APIServices.Fawry.Constants;
using AhliFans.SharedKernel.APIServices.Fawry.Extensions;
using AhliFans.SharedKernel.APIServices.Fawry.IRepository;
using AhliFans.SharedKernel.APIServices.Fawry.Model;
using AhliFans.SharedKernel.APIServices.Fawry.Settings;
using Microsoft.Extensions.Options;
namespace AhliFans.SharedKernel.APIServices.Fawry.Repository;

public class FawryPaymentService : IFawryPaymentService
{
  private readonly HttpClient _httpClient;

  private readonly FawrySettings _settings;

  public FawryPaymentService(IOptions<FawrySettings> options, IHttpClientFactory httpClientFactory)
  {
    _settings = options.Value;
    _httpClient = httpClientFactory.CreateClient();
  }

  public async Task<IPaymentResult> PayAsync(PaymentModel paymentModel)
  {
    var paymentRequest = GetPaymentRequest(paymentModel);

    var httpResponse = await _httpClient.PostAsJsonAsync(_settings.PaymentUrl, paymentRequest);

    var response = await httpResponse.Content.ReadFromJsonAsync<PaymentResponse>();

    return response!;
  }

  private PaymentRequest GetPaymentRequest(PaymentModel paymentModel)
  {
    var signatureString = new StringBuilder()
    .Append(_settings.MerchantCode)
    .Append(paymentModel.MerchantRefNum)
    .Append(paymentModel.CustomerProfileId)
    .Append(nameof(PaymentMethods.CARD))
    .Append(paymentModel.Amount.ToString("F2"))
    .Append(paymentModel.CardNumber)
    .Append(paymentModel.CardExpiryYear)
    .Append(paymentModel.CardExpiryMonth)
    .Append(paymentModel.Cvv)
    .Append(_settings.SecureKey)
    .ToString();

    var chargeItems = paymentModel.Items.Select(i => new ChargeItem()
    {
      Description = i.Description,
      ItemId = i.Id.ToString(),
      Price = decimal.Parse(i.Price.ToString("F2")),
      Quantity = i.Quantity
    }).ToList();

    var language = paymentModel.Language == "ar" ? PaymentConstants.Arabic : PaymentConstants.English;

    var paymentRequest = new PaymentRequest()
    {
      MerchantCode = _settings.MerchantCode,
      MerchantRefNum = paymentModel.MerchantRefNum,
      PaymentMethod = nameof(PaymentMethods.CARD),
      Cvv = paymentModel.Cvv.ToString(),
      CustomerMobile = paymentModel.CustomerMobile,
      CustomerEmail = paymentModel.CustomerEmail,
      Amount = decimal.Parse(paymentModel.Amount.ToString("F2")),
      Description = paymentModel.Description,
      Language = language,
      ChargeItems = chargeItems,
      Signature = HelperFunctions.GenerateSignature(signatureString),
      CustomerProfileId = paymentModel.CustomerProfileId,
      CardNumber = paymentModel.CardNumber.Trim().Replace(" ", ""),
      CardExpiryYear = paymentModel.CardExpiryYear,
      CardExpiryMonth = paymentModel.CardExpiryMonth,
      CurrencyCode = PaymentConstants.EgyptianCurrency,
      CustomerName = paymentModel.CustomerName
    };
    return paymentRequest;
  }
}
