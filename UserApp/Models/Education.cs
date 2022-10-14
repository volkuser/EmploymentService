using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserApp.Models;

public class Education
{
    [Key] [Required] 
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }

    private ICollection<Employed>? Employeds { get; set; }
    private ICollection<Profession>? Professions { get; set; }

    public Education()
    {
        Employeds = new List<Employed>();
        Professions = new List<Profession>();
    }
}