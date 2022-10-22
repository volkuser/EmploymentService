using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApp.Models;

[Table("Sex")]
public class Sex
{
    [Key] [Column("Id")]
    public char IdButChar { get; set; }
    [Column("Name")]
    public string? Name { get; set; }
}