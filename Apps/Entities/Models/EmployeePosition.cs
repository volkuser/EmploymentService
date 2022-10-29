using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("EmployeePosition")]
public class EmployeePosition
{
    [Key] [Column("Id")]
    public Guid Id { get; set; }
    [Column("EmployeeId")]
    public Guid EmployeeId { get; set; }
    [ForeignKey("Employee")]
    public Employee? Employee { get; set; }
    [Column("PositionId")]
    public Guid PositionId { get; set; }
    [ForeignKey("Position")]
    public Position? Position { get; set; }
}