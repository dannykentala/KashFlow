namespace KashFlow.Domain.DTOs;
public class ExcelDTO
{
  public CustomerDTO? Customer { get; set; }
  public EmployeeDTO? Employee { get; set; }
  public PlatformDTO? Platform { get; set; }
  public PaymentTypeDTO? PaymentType { get; set; }
  public BillDTO? Bill { get; set; }
  public PaymentDTO? Payment { get; set; }
}
