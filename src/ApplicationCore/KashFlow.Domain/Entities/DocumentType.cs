using System.Text.Json.Serialization;

namespace KashFlow.Domain.Entities;
public class DocumentType
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonIgnore]
    public List<Customer>? Customers { get; set; }
}
