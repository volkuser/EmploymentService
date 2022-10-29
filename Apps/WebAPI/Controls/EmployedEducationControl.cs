using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controls.Contracts;

namespace WebAPI.Controls;

public class EmployedEducationControl : IEmployedEducationControl
{
    private readonly Db _context;
    public EmployedEducationControl(Db context) => _context = context;
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

    public async Task<List<EmployedEducation?>> GetEmployedEducationsAsync() 
        => (await _context.EmployedEducations!.ToListAsync())!;
    public async Task<List<EmployedEducation?>> GetEducationsOfEmployedAsync(Guid employedId) 
        => (await _context.EmployedEducations!
            .Where(entity => entity.EmployedId.Equals(employedId))
            .ToListAsync())!;
    
    public async Task<EmployedEducation?> GetEmployedEducationDetailsAsync(Guid id)
        => await _context.EmployedEducations!.FindAsync(new object[] {id});

    public async Task InsertEmployedEducationAsync(EmployedEducation? entity)
        => await _context.EmployedEducations!.AddAsync(entity!);

    public async Task DeleteEmployedEducationAsync(Guid id)
    {
        var deletingEntity = await _context.EmployedEducations!.FindAsync(new object[] {id});
        if (deletingEntity == null) return;
        _context.EmployedEducations.Remove(deletingEntity);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

}