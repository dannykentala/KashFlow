namespace KashFlow.Domain.DTOs;

public class BillDTO
{
    public string? Code { get; set; }
    public double? Amount { get; set; }
    public DateTime? EndPaimentDate { get; set; }
    public string? PaymentType { get; set; }
}