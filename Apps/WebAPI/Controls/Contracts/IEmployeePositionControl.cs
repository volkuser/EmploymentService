using Entities.Models;

namespace WebAPI.Controls.Contracts;

public interface IEmployeePositionControl : IDisposable
{
    public Task<List<EmployeePosition?>> GetEmployeePositionsAsync();
    public Task<List<EmployeePosition?>> GetEmployeePositionsAsync(Guid employeeId);
    public Task<EmployeePosition?> GetEmployeePositionDetailsAsync(Guid id);
    public Task InsertEmployeePositionAsync(EmployeePosition? entity);
    public Task DeleteEmployeePositionAsync(Guid id);
    public Task SaveAsync();
}