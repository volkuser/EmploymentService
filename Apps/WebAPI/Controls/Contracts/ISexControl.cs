using Entities.Models;

namespace WebAPI.Controls.Contracts;

public interface ISexControl : IDisposable
{
    public Task<List<Sex?>> GetSexesAsync();
    public Task<Sex?> GetSexDetailsAsync(char id);
    public Task SaveAsync();
}