using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("Employed")]
public class Employed
{
    [Key] [Column("Id")]
    public int Id { get; set; }
    [Column("FirstName")] 
    public string? FirstName { get; set; }
    [Column("LastName")]
    public string? LastName { get; set; }
    [Column("Patronymic")]
    public string? Patronymic { get; set; }
    [Column("Email")]
    public string? Email { get; set; }
    [Column("Phone")]
    public string? Phone { get; set; }
    [Column("SexId")]
    public char SexId { get; set; }
    [ForeignKey("SexId")]
    public Sex? Sex { get; set; }
}