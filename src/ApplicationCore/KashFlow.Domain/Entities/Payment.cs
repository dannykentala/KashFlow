using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KashFlow.Domain.Entities.Enums;

namespace KashFlow.Domain.Entities;
public class Payment
{
    public int Id { get; set; }
    public string TransactionCode { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public PaymentStatusEnum Status { get; set; }

    public int BillId { get; set; }
    public int CustomerId { get; set; }
    public int PlatformId { get; set; }

    [ForeignKey(nameof(BillId))]
    public Bill? Bill { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer? Customer { get; set; }

    [ForeignKey(nameof(PlatformId))]
    public Platform? Platform { get; set; }
}