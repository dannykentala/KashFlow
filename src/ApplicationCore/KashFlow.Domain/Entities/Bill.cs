using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KashFlow.Domain.Entities;
public class Bill
{
    public int Id { get; set; }
    public string Code { get; set; }
    public double Amount { get; set; }
    public DateTime EndPaimentDate { get; set; }
    public int PaymentTypeId { get; set; }

    [ForeignKey(nameof(PaymentTypeId))]
    public PaymentType? PaymentType { get; set; }

    [JsonIgnore]
    public List<Payment>? Payments { get; set; }
}
