using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Vacancy")]
public class Vacancy
{
    [Key] [Column("Id")]
    public Guid Id { get; set; }
    [Column("Seniority")]
    public int Seniority { get; set; }
    [Column("EmployerId")]
    public Guid EmployerId { get; set; }
    [ForeignKey("EmployerId")]
    public Employer? Employer { get; set; }
    [Column("ProfessionId")]
    public Guid ProfessionId { get; set; }
    [ForeignKey("ProfessionId")]
    public Profession? Profession { get; set; }
}