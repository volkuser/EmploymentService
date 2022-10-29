using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controls.Contracts;

namespace WebAPI.Controls;

public class EducationForProfessionControl : IEducationForProfessionControl
{
    private readonly Db _context;
    public EducationForProfessionControl(Db context) => _context = context;
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

    public async Task<List<EducationForProfession?>> GetEducationsForProfessionsAsync() 
        => (await _context.EducationsForProfessions!.ToListAsync())!;
    
    public async Task<List<EducationForProfession?>> GetEducationsForProfessionAsync(Guid professionId) 
        => (await _context.EducationsForProfessions!
            .Where(entity => entity.ProfessionId.Equals(professionId))
            .ToListAsync())!;
    
    public async Task<EducationForProfession?> GetEducationForProfessionDetailsAsync(Guid id)
        => await _context.EducationsForProfessions!.FindAsync(new object[] {id});

    public async Task InsertEducationForProfessionAsync(EducationForProfession? entity)
        => await _context.EducationsForProfessions!.AddAsync(entity!);

    public async Task DeleteEducationForProfessionAsync(Guid id)
    {
        var deletingEntity 
            = await _context.EducationsForProfessions!.FindAsync(new object[] {id});
        if (deletingEntity == null) return;
        _context.EducationsForProfessions.Remove(deletingEntity);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}