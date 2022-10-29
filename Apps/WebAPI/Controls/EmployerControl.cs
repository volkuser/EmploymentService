using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controls.Contracts;

namespace WebAPI.Controls;

public class EmployerControl : IEmployerControl
{
    private readonly Db _context;
    public EmployerControl(Db context) => _context = context;
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

    public async Task<List<Employer?>> GetEmployersAsync() => (await _context.Employers!.ToListAsync())!;
    public async Task<List<Employer?>> GetEmployersAsync(string query) => (await _context.Employers!
        .Where(entity => entity.FirstName!.Contains(query)
        || entity.LastName!.Contains(query)
        || entity.Position!.Contains(query)
        || entity.PersonalPhone!.Contains(query)
        || entity.PersonalEmail!.Contains(query)
        || entity.OrganizationName!.Contains(query)
        || entity.SupportNumber!.Contains(query)
        || entity.SupportEmail!.Contains(query)
        || entity.RegistrationAddressOfOrganization!.Contains(query))
        .ToListAsync())!;
    
    public async Task<Employer?> GetEmployerDetailsAsync(Guid id)
        => await _context.Employers!.FindAsync(new object[] {id});

    public async Task InsertEmployerAsync(Employer? entity)
        => await _context.Employers!.AddAsync(entity!);

    public async Task UpdateEmployerAsync(Employer? entity)
    {
        if (entity == null) return;
        var updatingEntity = await _context.Employers!.FindAsync(new object[] {entity.Id});
        updatingEntity!.FirstName = entity.FirstName;
        updatingEntity.LastName = entity.LastName;
        updatingEntity.Position = entity.Position;
        updatingEntity.PersonalPhone = entity.PersonalPhone;
        updatingEntity.PersonalEmail = entity.PersonalEmail;
        updatingEntity.OrganizationName = entity.OrganizationName;
        updatingEntity.SupportNumber = entity.SupportNumber;
        updatingEntity.SupportEmail = entity.SupportEmail;
        updatingEntity.RegistrationAddressOfOrganization = entity.RegistrationAddressOfOrganization;
        _context.Employers.Update(updatingEntity);
    }

    public async Task DeleteEmployerAsync(Guid id)
    {
        var deletingEntity = await _context.Employers!.FindAsync(new object[] {id});
        if (deletingEntity == null) return;
        _context.Employers.Remove(deletingEntity);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

}