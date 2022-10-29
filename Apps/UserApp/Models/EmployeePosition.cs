using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApp.Models;

[Table("EmployeePosition")]
public class EmployeePosition
{
    [Key] [Column("Id")]
    public int Id { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee? Employee { get; set; }
    [ForeignKey("PositionId")]
    public Position? Position { get; set; }
}