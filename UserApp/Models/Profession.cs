using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserApp.Models;

public class Profession
{
    [Key] [Required]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    
    private ICollection<Education> Educations { get; set; }
    private Profession() => Educations = new List<Education>();
}