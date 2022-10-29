using Entities.Models;

namespace WebAPI.Controls.Contracts;

public interface IProfessionControl : IDisposable
{
    public Task<List<Profession?>> GetProfessionsAsync();
    public Task<List<Profession?>> GetProfessionsAsync(string name);
    public Task<Profession?> GetProfessionDetailsAsync(Guid id);
    public Task InsertProfessionAsync(Profession? entity);
    public Task UpdateProfessionAsync(Profession? entity);
    public Task DeleteProfessionAsync(Guid id);
    public Task SaveAsync();
}