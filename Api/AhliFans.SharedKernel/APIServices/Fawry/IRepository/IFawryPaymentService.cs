using AhliFans.SharedKernel.APIServices.Fawry.Model;

namespace AhliFans.SharedKernel.APIServices.Fawry.IRepository;

public interface IFawryPaymentService
{
  Task<IPaymentResult> PayAsync(PaymentModel paymentModel);
}
