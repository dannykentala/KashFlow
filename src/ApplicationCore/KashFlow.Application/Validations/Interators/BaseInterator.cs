using KashFlow.Domain.Entities;

namespace KashFlow.Application.Validations.Interators;
public class BaseIterator<T>
{
  public T Data {get; set;}
  public bool Succeded {get
  {
    return Errors.Count <= 0;
  }}

  public List<Error> Errors {get;} 

  public BaseIterator ()
  {
    Errors = new List<Error>();
  }
}