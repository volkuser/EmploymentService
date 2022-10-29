using Entities.Models;

namespace WebAPI.Controls.Contracts;

public interface IEmployedControl : IDisposable
{
    public Task<List<Employed?>> GetEmployedsAsync();
    public Task<List<Employed?>> GetEmployedsByQueryAsync(string query);
    public Task<List<Employed?>> GetEmployedsBySexAsync(char sexId);
    public Task<Employed?> GetEmployedDetailsAsync(Guid id);
    public Task InsertEmployedAsync(Employed? entity);
    public Task UpdateEmployedAsync(Employed? entity);
    public Task DeleteEmployedAsync(Guid id);
    public Task SaveAsync(); 
}