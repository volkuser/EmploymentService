using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Position")]
public class Position
{
    [Key] [Column("Id")]
    public Guid Id { get; set; }
    [Column("Name")]
    public string? Name { get; set; }
    [Column("Salary")]
    public decimal Salary { get; set; }
}