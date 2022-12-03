namespace AhliFans.SharedKernel.Logging;
public class ErrorLogger
{
  public string ErrorDetails { get; set; } = String.Empty;
  public int StatusCode { get; set; } = 0;
  public string EndPointName { get; set; } = String.Empty;
  public override string ToString()
  {
    return ErrorDetails+" ----- status code:["+StatusCode+"] ----- EndPoint ["+EndPointName+"]";
  }
}
