using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("JobApplication")]
public class JobApplication
{
    [Key] [Column("Id")]
    public int Id { get; set; }
    [Column("VacancyId")]
    public int VacancyId { get; set; }
    [ForeignKey("VacancyId")]
    public Vacancy? Vacancy { get; set; }
    [Column("EmployedId")]
    public int EmployedId { get; set; }
    [ForeignKey("EmployedId")]
    public Employed? Employed { get; set; }
    [Column("EmployeeId")]
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee? Employee { get; set; }
}