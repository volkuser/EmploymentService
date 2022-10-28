using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controls;

public class ProfessionControl : IProfessionControl
{
    private readonly Db _context;
    public ProfessionControl(Db context) => _context = context;
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

    public async Task<List<Profession?>> GetProfessionsAsync() => (await _context.Professions!.ToListAsync())!;

    public async Task<Profession?> GetProfessionDetailsAsync(Guid id)
        => await _context.Professions!.FindAsync(new object[] {id});

    public async Task InsertProfessionAsync(Profession? entity)
        => await _context.Professions!.AddAsync(entity!);

    public async Task UpdateProfessionAsync(Profession? entity)
    {
        if (entity == null) return;
        var updatingEntity = await _context.Professions!.FindAsync(new object[] {entity.Id});
        updatingEntity!.Name = entity.Name;
        _context.Professions.Update(updatingEntity);
    }

    public async Task DeleteProfessionAsync(Guid id)
    {
        var deletingEntity = await _context.Professions!.FindAsync(new object[] {id});
        if (deletingEntity == null) return;
        _context.Professions.Remove(deletingEntity);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}