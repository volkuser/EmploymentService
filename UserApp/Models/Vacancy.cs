using System.ComponentModel.DataAnnotations;

namespace UserApp.Models;

public class Vacancy
{
    [Key] [Required]
    public int Id { get; set; }
    [Required]
    public float Salary { get; set; }
    [Required]
    public Employer? Employer { get; set; }
    [Required]
    public Profession? Profession { get; set; }
}