#nullable disable
using System.Text.Json;

namespace AhliFans.SharedKernel.APIServices.Location;
public class Countries
{
  static readonly HttpClient Client = new();

  public static async Task<List<Class1>> GetAllCountries()
  {
    var url = "https://restcountries.com/v2/all";

    var response = await Client.GetAsync(url);
    response.EnsureSuccessStatusCode();

    var responseBody = await response.Content.ReadAsStringAsync();
    var countries = JsonSerializer.Deserialize<List<Class1>>(responseBody);

    return countries;
  }

}

#region Json to classes
public class Rootobject
{
  public Class1[] Property1 { get; set; }
}

public class Class1
{
  public string name { get; set; }
  public string nativeName { get; set; }
  public Translations translations { get; set; }

}

public class Translations
{
  public string fa { get; set; }
}
#endregion
