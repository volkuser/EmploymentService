using Entities.Models;

namespace WebAPI.Controls.Contracts;

public interface IEducationForProfessionControl : IDisposable
{
    public Task<List<EducationForProfession?>> GetEducationsForProfessionsAsync();
    public Task<List<EducationForProfession?>> GetEducationsForProfessionAsync(Guid professionId);
    public Task<EducationForProfession?> GetEducationForProfessionDetailsAsync(Guid id);
    public Task InsertEducationForProfessionAsync(EducationForProfession? entity);
    public Task DeleteEducationForProfessionAsync(Guid id);
    public Task SaveAsync();
}