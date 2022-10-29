using Entities.Models;

namespace WebAPI.Controls.Contracts;

public interface IEmployerControl : IDisposable
{
    public Task<List<Employer?>> GetEmployersAsync();
    public Task<List<Employer?>> GetEmployersAsync(string query);
    public Task<Employer?> GetEmployerDetailsAsync(Guid id);
    public Task InsertEmployerAsync(Employer? entity);
    public Task UpdateEmployerAsync(Employer? entity);
    public Task DeleteEmployerAsync(Guid id);
    public Task SaveAsync();
}