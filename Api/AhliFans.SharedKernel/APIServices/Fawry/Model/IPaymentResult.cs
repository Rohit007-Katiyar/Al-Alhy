using AhliFans.SharedKernel.APIServices.Fawry.Constants;
namespace AhliFans.SharedKernel.APIServices.Fawry.Model;

public interface IPaymentResult
{
  string ErrorMessage { get; }

  bool IsSuccessful { get; }

  PaymentStatus Status { get; }
}
