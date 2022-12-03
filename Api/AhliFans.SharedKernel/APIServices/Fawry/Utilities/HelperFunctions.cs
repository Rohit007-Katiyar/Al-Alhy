using System.Security.Cryptography;
using System.Text;

namespace AhliFans.SharedKernel.APIServices.Fawry.Extensions;

public static class HelperFunctions
{
  public static string GenerateSignature(string value)
  {
    var sb = new StringBuilder();

    using (var hash = SHA256.Create())
    {
      Encoding enc = Encoding.UTF8;
      byte[] result = hash.ComputeHash(enc.GetBytes(value));

      foreach (byte b in result)
        sb.Append(b.ToString("x2"));
    }

    return sb.ToString();
  }
}
