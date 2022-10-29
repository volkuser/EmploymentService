using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controls.Contracts;

namespace WebAPI.Controls;

public class PositionControl : IPositionControl
{
    private readonly Db _context;
    public PositionControl(Db context) => _context = context;
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
    public async Task<List<Position?>> GetPositionsAsync() => (await _context.Positions!.ToListAsync())!;

    public async Task<Position?> GetPositionDetailsAsync(Guid id)
        => await _context.Positions!.FindAsync(new object[] {id});
    
    public async Task UpdatePositionAsync(Position? entity)
    {
        if (entity == null) return;
        var updatingEntity = await _context.Positions!.FindAsync(new object[] {entity.Id});
        updatingEntity!.Name = entity.Name;
        updatingEntity.Salary = entity.Salary;
        _context.Positions.Update(updatingEntity);
    }
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}