using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("EmployeePosition")]
public class EmployeePosition
{
    [Key] [Column("Id")]
    public Guid Id { get; set; }
    [Column("DateOfHire")]
    public DateTime DateOfHire { get; set; }
    [Column("Employee")]
    public Employee? Employee { get; set; }
    [Column("Position")]
    public Position? Position { get; set; }
}