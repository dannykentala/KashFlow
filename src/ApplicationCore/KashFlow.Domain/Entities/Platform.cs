using System.Text.Json.Serialization;

namespace KashFlow.Domain.Entities;
public class Platform
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonIgnore]
    public List<Payment>? Payments { get; set; }
}
