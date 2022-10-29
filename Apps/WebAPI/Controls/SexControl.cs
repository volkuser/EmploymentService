using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controls.Contracts;

namespace WebAPI.Controls;

public class SexControl : ISexControl
{
    private readonly Db _context;
    public SexControl(Db context) => _context = context;
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

    public async Task<List<Sex?>> GetSexesAsync() => (await _context.Sexes!.ToListAsync())!;

    public async Task<Sex?> GetSexDetailsAsync(char id)
        => await _context.Sexes!.FindAsync(new object[] {id});

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}