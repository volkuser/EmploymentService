using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("EmployeePosition")]
public class EmployeePosition
{
    [Key] [Column("Id")]
    public int Id { get; set; }
    [Column("DateOfHire")]
    public DateTime DateOfHire { get; set; }
    [Column("Employee")]
    public Employee? Employee { get; set; }
    [Column("Position")]
    public Position? Position { get; set; }
}