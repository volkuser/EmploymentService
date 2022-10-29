using Entities.Models;

namespace WebAPI.Controls.Contracts;

public interface IEducationControl : IDisposable
{
    public Task<List<Education?>> GetEducationsAsync();
    public Task<List<Education?>> GetEducationsAsync(string name);
    public Task<Education?> GetEducationDetailsAsync(int id);
    public Task SaveAsync();
}