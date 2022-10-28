using Entities.Models;

namespace WebAPI.Controls;

public interface IProfessionControl : IDisposable
{
    public Task<List<Profession?>> GetProfessionsAsync();
    public Task<Profession?> GetProfessionDetailsAsync(Guid id);
    public Task InsertProfessionAsync(Profession? entity);
    public Task UpdateProfessionAsync(Profession? entity);
    public Task DeleteProfessionAsync(Guid id);
    public Task SaveAsync();
}