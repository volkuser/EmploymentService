using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controls.Contracts;

namespace WebAPI.Controls;

public class VacancyControl : IVacancyControl
{
    private readonly Db _context;
    public VacancyControl(Db context) => _context = context;
    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed) if (disposing) _context.Dispose();
        _disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task<List<Vacancy?>> GetVacanciesAsync() => (await _context.Vacancies!.ToListAsync())!;
    
    public async Task<List<Vacancy?>> GetVacanciesByProfessionAsync(Guid professionId) => (await _context.Vacancies!
        .Where(entity => entity.ProfessionId.Equals(professionId)).ToListAsync())!;
    
    public async Task<Vacancy?> GetVacancyDetailsAsync(Guid id)
        => await _context.Vacancies!.FindAsync(new object[] {id});

    public async Task InsertVacancyAsync(Vacancy? entity)
        => await _context.Vacancies!.AddAsync(entity!);

    public async Task UpdateVacancyAsync(Vacancy? entity)
    {
        if (entity == null) return;
        var updatingEntity = await _context.Vacancies!.FindAsync(new object[] {entity.Id});
        updatingEntity!.Seniority = entity.Seniority;
        updatingEntity.EmployerId = entity.EmployerId;
        updatingEntity.ProfessionId = entity.ProfessionId;
        _context.Vacancies.Update(updatingEntity);
    }

    public async Task DeleteVacancyAsync(Guid id)
    {
        var deletingEntity = await _context.Vacancies!.FindAsync(new object[] {id});
        if (deletingEntity == null) return;
        _context.Vacancies.Remove(deletingEntity);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

}