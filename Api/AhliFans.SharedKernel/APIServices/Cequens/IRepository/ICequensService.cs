using AhliFans.SharedKernel.APIServices.Cequens.Enums;
using AhliFans.SharedKernel.APIServices.Cequens.Model;

namespace AhliFans.SharedKernel.APIServices.Cequens.IRepository;
public interface ICequensService
{
  Task<ISendOtpResult> SendOTPAsync(string mobileNumber);

  Task<OtpValidationState> ValidateOTPAsync(string otp, string checkCode);

  Task<OtpValidationState> CheckOTPStatusAsync(string checkCode);
}
