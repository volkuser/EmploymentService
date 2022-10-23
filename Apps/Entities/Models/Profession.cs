using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table(("Profession"))]
public class Profession
{
    [Key] [Column("Id")]
    public Guid Id { get; set; }
    [Column("Name")]
    public string? Name { get; set; }
}