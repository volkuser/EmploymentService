using Entities.Models;

namespace WebAPI.Controls.Contracts;

public interface IEmployeeControl : IDisposable
{
    public Task<List<Employee?>> GetEmployeesAsync();
    public Task<List<Employee?>> GetEmployeesAsync(string query);
    public Task<Employee?> GetEmployeeDetailsAsync(Guid id);
    public Task SaveAsync();
}