using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("Employee")]
public class Employee
{
    [Key] [Column("Id")]
    public int Id { get; set; }
    [Column("FirstName")]
    public string? FirstName { get; set; }
    [Column("LastName")]
    public string? LastName { get; set; }
    [Column("Email")]
    public string? Email { get; set; }
    [Column("Password")]
    public string? Password { get; set; }
}