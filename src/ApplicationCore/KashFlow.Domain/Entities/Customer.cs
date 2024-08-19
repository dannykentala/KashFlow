using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KashFlow.Domain.Entities;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long Document { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public int DocumentTypeId { get; set; }

    [ForeignKey(nameof(DocumentTypeId))]
    public DocumentType? DocumentType { get; set; }

    [JsonIgnore]
    public List<Payment>? Payments { get; set; }
}