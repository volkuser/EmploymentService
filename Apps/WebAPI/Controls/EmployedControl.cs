using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controls.Contracts;

namespace WebAPI.Controls;

public class EmployedControl : IEmployedControl
{
    private readonly Db _context;
    public EmployedControl(Db context) => _context = context;
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
    public async Task<List<Employed?>> GetEmployedsAsync() => (await _context.Employeds!.ToListAsync())!;
    public async Task<List<Employed?>> GetEmployedsByQueryAsync(string query) => (await _context.Employeds!
        .Where(entity => entity.FirstName!.Contains(query) 
                         || entity.LastName!.Contains(query)
                         || entity.Patronymic!.Contains(query)
                         || entity.Email!.Contains(query)
                         || entity.Phone!.Contains(query)).ToListAsync())!;
    public async Task<List<Employed?>> GetEmployedsBySexAsync(char sexId) => (await _context.Employeds!
        .Where(entity => entity.SexId.Equals(sexId))
        .ToListAsync())!;
    
    public async Task<Employed?> GetEmployedDetailsAsync(Guid id)
        => await _context.Employeds!.FindAsync(new object[] {id});
    public async Task InsertEmployedAsync(Employed? entity)
        => await _context.Employeds!.AddAsync(entity!);
    public async Task UpdateEmployedAsync(Employed? entity)
    {
        if (entity == null) return;
        var updatingEntity = await _context.Employeds!.FindAsync(new object[] {entity.Id});
        updatingEntity!.FirstName = entity.FirstName;
        updatingEntity.LastName = entity.LastName;
        updatingEntity.Patronymic = entity.Patronymic;
        updatingEntity.Email = entity.Email;
        updatingEntity.Phone = entity.Phone;
        updatingEntity.SexId = entity.SexId;
        _context.Employeds.Update(updatingEntity);
    }
    public async Task DeleteEmployedAsync(Guid id)
    {
        var deletingEntity = await _context.Employeds!.FindAsync(new object[] {id});
        if (deletingEntity == null) return;
        _context.Employeds.Remove(deletingEntity);
    }
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}