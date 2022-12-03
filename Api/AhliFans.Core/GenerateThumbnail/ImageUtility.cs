using Org.BouncyCastle.Asn1.Ocsp;
using System.Net;

namespace AhliFans.Core.GenerateThumbnail;
public static class ImageUtility
{
  public static string GetYouTubeThumbnail(string url)
  {
    string youTubeThumb = string.Empty;
    if (string.IsNullOrEmpty(url))
      return "";

    if (url.IndexOf("=") > 0)
    {
      youTubeThumb = url.Split('=')[1];
    }
    else if (url.IndexOf("/v/") > 0)
    {
      string strVideoCode = url.Substring(url.IndexOf("/v/") + 3);
      int ind = strVideoCode.IndexOf("?");
      youTubeThumb = strVideoCode.Substring(0, ind == -1 ? strVideoCode.Length : ind);
    }
    else if (url.IndexOf('/') < 6)
    {
      youTubeThumb = url.Split('/')[3];
    }
    else if (url.IndexOf('/') > 6)
    {
      youTubeThumb = url.Split('/')[1];
    }

    return "http://img.youtube.com/vi/" + youTubeThumb + "/mqdefault.jpg";
  }

  public static string SaveThumbnail(string url, string name, string type)
  {
    var thumbnailUrl = ImageUtility.GetYouTubeThumbnail(url);
    string _name = name + ".png";
    using (WebClient client = new WebClient())
    {
      var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\" + type, _name);
      client.DownloadFile(new Uri(thumbnailUrl), filePath);
    }
    return name;
  }
}
