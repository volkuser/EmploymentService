using System.ComponentModel.DataAnnotations;

namespace UserApp.Models;

public class JobApplication
{
    [Key] [Required]
    public int Id { get; set; }
    [Required]
    public Vacancy? Vacancy { get; set; }
    [Required]
    public Employed? Employed { get; set; }
    [Required]
    public Employee? Employee { get; set; }
}