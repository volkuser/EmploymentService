using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Input;

namespace Entities.Models;

[Table("Employee")]
public class Employee
{
    [Key] [Column("Id")]
    public Guid Id { get; set; }
    [Column("FirstName")]
    public string? FirstName { get; set; }
    [Column("LastName")]
    public string? LastName { get; set; }
    [Column("Login")]
    public string? Login { get; set; }
    [Column("Password")]
    public string? Password { get; set; }
    
    [NotMapped]
    public ICommand? CmdPositions { get; set; }
}