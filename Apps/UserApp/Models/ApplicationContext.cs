using Microsoft.EntityFrameworkCore;

namespace UserApp.Models;

public class ApplicationContext : DbContext
{
    public DbSet<Education>? Educations { get; set; }
    public DbSet<Employed>? Employeds { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<EmployeePosition>? EmployeePositions { get; set; }
    public DbSet<Employer>? Employers { get; set; }
    public DbSet<JobApplication>? JobApplications { get; set; }
    public DbSet<Position>? Positions { get; set; }
    public DbSet<Profession>? Professions { get; set; }
    public DbSet<Sex>? Sexes { get; set; }
    public DbSet<Vacancy>? Vacancies { get; set; }
    public DbSet<EducationForProfession>? EducationsForProfessions { get; set; }
    public DbSet<EmployedEducation>? EmployedEducations { get; set; }

    public ApplicationContext() => Database.EnsureCreated();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;" + 
                                 "Database=EmploymentService;Username=postgres;Password=321");
    }
}