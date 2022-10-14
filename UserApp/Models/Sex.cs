using System.ComponentModel.DataAnnotations;

namespace UserApp.Models;

public class Sex
{
    [Key] [Required]
    public char Id { get; set; }
    [Required]
    public string? Name { get; set; }
}