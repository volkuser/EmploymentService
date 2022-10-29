using Entities.Models;

namespace WebAPI.Controls.Contracts;

public interface IPositionControl : IDisposable
{
    public Task<List<Position?>> GetPositionsAsync();
    public Task<Position?> GetPositionDetailsAsync(Guid id);
    public Task UpdatePositionAsync(Position? entity);
    public Task SaveAsync();
}