using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Vacancy")]
public class Vacancy
{
    [Key] [Column("Id")]
    public int Id { get; set; }
    [Column("Salary")]
    public float Salary { get; set; }
    [Column("EmployerId")]
    public int EmployerId { get; set; }
    [ForeignKey("EmployerId")]
    public Employer? Employer { get; set; }
    [Column("ProfessionId")]
    public int ProfessionId { get; set; }
    [ForeignKey("ProfessionId")]
    public Profession? Profession { get; set; }
}