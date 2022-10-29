using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controls.Contracts;

namespace WebAPI.Controls;

public class EmployeePositionControl : IEmployeePositionControl
{
    private readonly Db _context;
    public EmployeePositionControl(Db context) => _context = context;
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

    public async Task<List<EmployeePosition?>> GetEmployeePositionsAsync() 
        => (await _context.EmployeePositions!.ToListAsync())!;
    public async Task<List<EmployeePosition?>> GetEmployeePositionsAsync(Guid employeeId) 
        => (await _context.EmployeePositions!
        .Where(entity => entity.EmployeeId!.Equals(employeeId)).ToListAsync())!;
    
    public async Task<EmployeePosition?> GetEmployeePositionDetailsAsync(Guid id)
        => await _context.EmployeePositions!.FindAsync(new object[] {id});

    public async Task InsertEmployeePositionAsync(EmployeePosition? entity)
        => await _context.EmployeePositions!.AddAsync(entity!);

    public async Task DeleteEmployeePositionAsync(Guid id)
    {
        var deletingEntity = await _context.EmployeePositions!.FindAsync(new object[] {id});
        if (deletingEntity == null) return;
        _context.EmployeePositions.Remove(deletingEntity);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

}