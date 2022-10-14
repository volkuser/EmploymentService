using System.ComponentModel.DataAnnotations;

namespace UserApp.Models;

public class Employer
{
    [Key] [Required]
    public int Id { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? Position { get; set; }
    [Required]
    public string? PersonalPhone { get; set; }
    [Required]
    public string? PersonalEmail { get; set; }
    [Required]
    public string? OrganizationName { get; set; }
    [Required]
    public string? SupportNumber { get; set; }
    [Required]
    public string? SupportEmail { get; set; }
    [Required]
    public string? RegistrationAddressOfOrganization { get; set; }
}