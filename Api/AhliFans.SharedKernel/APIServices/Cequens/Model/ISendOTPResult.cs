namespace AhliFans.SharedKernel.APIServices.Cequens.Model;

public interface ISendOtpResult
{
  string ErrorMessage { get; }

  bool IsSuccessful { get; }

  string CheckCode { get; }
}
