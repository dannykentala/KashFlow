namespace KashFlow.Domain.DTOs.Setters;

public class CustomerCreateDTO
{
    public string? Name { get; set; }
    public long? Document { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? DocumentType { get; set; }
}
