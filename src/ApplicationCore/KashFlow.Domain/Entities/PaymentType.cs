using System.Text.Json.Serialization;

namespace KashFlow.Domain.Entities;
public class PaymentType
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonIgnore]
    public List<Bill> Bills { get; set; }
}
