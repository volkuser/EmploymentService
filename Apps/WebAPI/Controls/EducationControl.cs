using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controls.Contracts;

namespace WebAPI.Controls;

public class EducationControl : IEducationControl
{
    private readonly Db _context;
    public EducationControl(Db context) => _context = context;
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
    
    public async Task<List<Education?>> GetEducationsAsync() => (await _context.Educations!.ToListAsync())!;
    public async Task<List<Education?>> GetEducationsAsync(string name) => (await _context.Educations!
        .Where(entity => entity.Name!.Contains(name)).ToListAsync())!;

    public async Task<Education?> GetEducationDetailsAsync(int id)
        => await _context.Educations!.FindAsync(new object[] {id});
    
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}