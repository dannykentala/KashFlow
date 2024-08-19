namespace KashFlow.Domain.DTOs;

public class PaymentDTO
{
    public string? TransactionCode { get; set; }
    public DateTime? Date { get; set; }
    public double? Amount { get; set; }
    public string? Status { get; set; }
    public string? BillCode { get; set; }
    public string? Customer { get; set; }
    public string? Platform { get; set; }
}