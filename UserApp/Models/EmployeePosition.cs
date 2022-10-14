using System.ComponentModel.DataAnnotations;

namespace UserApp.Models;

public class EmployeePosition
{
    [Key] [Required]
    public int Id { get; set; }
    [Required]
    public Employee? Employee { get; set; }
    [Required]
    public Position? Position { get; set; }
}