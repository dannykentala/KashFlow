using System.ComponentModel.DataAnnotations;
using KashFlow.Domain.Entities.Enums;

namespace KashFlow.Domain.Entities;
public class Employee
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleEnum Role { get; set; }
}