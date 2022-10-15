using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("Education")]
public class Education
{
    [Key] [Column("Id")] 
    public int Id { get; set; }
    [Column("Name")]
    public string? Name { get; set; }
}