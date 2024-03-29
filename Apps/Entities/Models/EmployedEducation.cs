using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("EmployedEducation")]
public class EmployedEducation
{
    [Key] [Column("Id")]
    public Guid Id { get; set; }
    [Column("EducationId")]
    public int EducationId { get; set; }
    [ForeignKey("EducationId")]
    public Education? Education { get; set; }
    [Column("EmployedId")]
    public Guid EmployedId { get; set; }
    [ForeignKey("EmployedId")]
    public Employed? Employed { get; set; }
}