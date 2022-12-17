using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Input;

namespace Entities.Models;

[Table(("Profession"))]
public class Profession
{
    [Key] [Column("Id")]
    public Guid Id { get; set; }
    [Column("Name")]
    public string? Name { get; set; }
    
    [NotMapped]
    public ICommand? CmdEducations { get; set; }
}