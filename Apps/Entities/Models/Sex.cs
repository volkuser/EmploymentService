using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Sex")]
public class Sex
{
    [Key] [Column("Id")]
    public char Id { get; set; }
    [Column("Name")]
    public string? Name { get; set; }
}