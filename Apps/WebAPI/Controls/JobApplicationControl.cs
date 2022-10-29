using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controls.Contracts;

namespace WebAPI.Controls;

public class JobApplicationControl : IJobApplicationControl
{
    private readonly Db _context;
    public JobApplicationControl(Db context) => _context = context;
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

    public async Task<List<JobApplication?>> GetJobApplicationsAsync() 
        => (await _context.JobApplications!.ToListAsync())!;
    public async Task<List<JobApplication?>> GetJobApplicationsAsync(Guid employedId) 
        => (await _context.JobApplications!
        .Where(entity => entity.EmployedId.Equals(employedId)).ToListAsync())!;
    
    public async Task<JobApplication?> GetJobApplicationDetailsAsync(Guid id)
        => await _context.JobApplications!.FindAsync(new object[] {id});

    public async Task InsertJobApplicationAsync(JobApplication? entity)
        => await _context.JobApplications!.AddAsync(entity!);

    public async Task DeleteJobApplicationAsync(Guid id)
    {
        var deletingEntity = await _context.JobApplications!.FindAsync(new object[] {id});
        if (deletingEntity == null) return;
        _context.JobApplications.Remove(deletingEntity);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

}