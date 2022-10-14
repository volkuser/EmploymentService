using System.ComponentModel.DataAnnotations;

namespace UserApp.Models;

public class Position
{
    [Key] [Required]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public float Salary { get; set; }
}