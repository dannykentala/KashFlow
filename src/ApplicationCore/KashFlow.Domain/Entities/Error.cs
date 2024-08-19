namespace KashFlow.Domain.Entities;
public class Error
{
  public string Code { get; set; }
  public string ErrorName {get; set;}
  public string Message {get; set;}

  public Error()
  { }

  public Error(string errorName, string message)
  {
    ErrorName = errorName;
    Message = message;
  }
}