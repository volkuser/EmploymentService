using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controls.Contracts;

namespace WebAPI.Controls;

public class EmployeeControl : IEmployeeControl
{
    private readonly Db _context;
    public EmployeeControl(Db context) => _context = context;
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

    public async Task<List<Employee?>> GetEmployeesAsync() => (await _context.Employees!.ToListAsync())!;
    public async Task<List<Employee?>> GetEmployeesAsync(string query) => (await _context.Employees!
        .Where(entity => entity.FirstName!.Contains(query)
        || entity.LastName!.Contains(query)
        || entity.Email!.Contains(query)).ToListAsync())!;
    
    public async Task<Employee?> GetEmployeeDetailsAsync(Guid id)
        => await _context.Employees!.FindAsync(new object[] {id});

    public async Task SaveAsync() => await _context.SaveChangesAsync();

}