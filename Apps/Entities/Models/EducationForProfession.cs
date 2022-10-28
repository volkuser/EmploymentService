using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("EducationForProfession")]
public class EducationForProfession
{
    [Key] [Column("Id")]
    public Guid Id { get; set; }
    [Column("EducationId")]
    public int EducationId { get; set; }
    [ForeignKey("EducationId")]
    public Education? Education { get; set; }
    [Column("ProfessionId")]
    public Guid ProfessionId { get; set; }
    [ForeignKey("ProfessionId")]
    public Profession? Profession { get; set; }
}