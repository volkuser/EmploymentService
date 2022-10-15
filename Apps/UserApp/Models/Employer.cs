using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApp.Models;

[Table("Employer")]
public class Employer
{
    [Key] [Column("Id")]
    public int Id { get; set; }
    [Column("FirstName")]
    public string? FirstName { get; set; }
    [Column("LastName")]
    public string? LastName { get; set; }
    [Column("Position")]
    public string? Position { get; set; }
    [Column("PersonalPhone")]
    public string? PersonalPhone { get; set; }
    [Column("PersonalEmail")]
    public string? PersonalEmail { get; set; }
    [Column("OrganizationName")]
    public string? OrganizationName { get; set; }
    [Column("SupportNumber")]
    public string? SupportNumber { get; set; }
    [Column("SupportEmail")]
    public string? SupportEmail { get; set; }
    [Column("RegistrationAddressOfOrganization")]
    public string? RegistrationAddressOfOrganization { get; set; }
}