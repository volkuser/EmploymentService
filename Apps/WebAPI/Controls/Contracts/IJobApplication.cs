using Entities.Models;

namespace WebAPI.Controls.Contracts;

public interface IJobApplicationControl : IDisposable
{
    public Task<List<JobApplication?>> GetJobApplicationsAsync();
    public Task<List<JobApplication?>> GetJobApplicationsAsync(Guid employedId);
    public Task<JobApplication?> GetJobApplicationDetailsAsync(Guid id);
    public Task InsertJobApplicationAsync(JobApplication? entity);
    public Task DeleteJobApplicationAsync(Guid id);
    public Task SaveAsync();
}