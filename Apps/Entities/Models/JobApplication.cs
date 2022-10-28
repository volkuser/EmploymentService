using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("JobApplication")]
public class JobApplication
{
    [Key] [Column("Id")]
    public Guid Id { get; set; }
    [Column("VacancyId")]
    public Guid VacancyId { get; set; }
    [ForeignKey("VacancyId")]
    public Vacancy? Vacancy { get; set; }
    [Column("EmployedId")]
    public Guid EmployedId { get; set; }
    [ForeignKey("EmployedId")]
    public Employed? Employed { get; set; }
    [Column("EmployeeId")]
    public Guid EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee? Employee { get; set; }
}