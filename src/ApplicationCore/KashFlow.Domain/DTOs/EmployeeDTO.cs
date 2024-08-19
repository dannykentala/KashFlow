using System.ComponentModel.DataAnnotations;

namespace KashFlow.Domain.DTOs;

public class EmployeeDTO
{
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? Email { get; set; }

    [MinLength(8, ErrorMessage = "Password must be logger than 8 characthers")]
    public string? Password { get; set; }
    public string? Role { get; set; }
}