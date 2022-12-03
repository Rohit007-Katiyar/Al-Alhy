using AhliFans.SharedKernel.APIServices.FaceBook.Model;

namespace AhliFans.SharedKernel.APIServices.FaceBook.IRepository;

public interface IFaceBookAuthService
{
  Task<FaceBookTokenValidation> ValidationAccessToken(string accessToken);
  Task<FaceBookUserInfo> GetUserInfo(string accessToken);
}
