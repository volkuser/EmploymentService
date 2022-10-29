using Entities.Models;

namespace WebAPI.Controls.Contracts;

public interface IVacancyControl : IDisposable
{
    public Task<List<Vacancy?>> GetVacanciesAsync();
    public Task<List<Vacancy?>> GetVacanciesByProfessionAsync(Guid professionId);
    public Task<Vacancy?> GetVacancyDetailsAsync(Guid id);
    public Task InsertVacancyAsync(Vacancy? entity);
    public Task UpdateVacancyAsync(Vacancy? entity);
    public Task DeleteVacancyAsync(Guid id);
    public Task SaveAsync();
}