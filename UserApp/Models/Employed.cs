using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserApp.Models;

public class Employed
{
    [Key] [Required]
    public int Id { get; set; }
    [Required] 
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Phone { get; set; }
    [Required]
    public Sex? Sex { get; set; }
    
    private ICollection<Education>? Educations { get; set; }
    public Employed() => Educations = new List<Education>();
}