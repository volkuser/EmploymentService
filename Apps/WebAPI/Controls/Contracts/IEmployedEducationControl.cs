using Entities.Models;

namespace WebAPI.Controls.Contracts;

public interface IEmployedEducationControl : IDisposable
{
    public Task<List<EmployedEducation?>> GetEmployedEducationsAsync();
    public Task<List<EmployedEducation?>> GetEducationsOfEmployedAsync(Guid employedId);
    public Task<EmployedEducation?> GetEmployedEducationDetailsAsync(Guid id);
    public Task InsertEmployedEducationAsync(EmployedEducation? entity);
    public Task DeleteEmployedEducationAsync(Guid id);
    public Task SaveAsync();
}