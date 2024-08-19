using KashFlow.Domain.Entities.Enums;

namespace KashFlow.Domain.DTOs.Setters;

public class PaymentCreateDTO
{
    // Should be also autogenarated TransactionCode
    // public string? TransactionCode { get; set; }

    /*
        ## No se pide la fecha
        Esta fecha no se le pide al usuario, se debe agregar internamente por el sistema
    */
    // public DateTime? Date { get; set; }
    public double? Amount { get; set; }
    public string? Status { get; set; }
    public string? BillCode { get; set; }
    public string? CustomerEmail { get; set; }
    public string? PlatformName { get; set; }
}