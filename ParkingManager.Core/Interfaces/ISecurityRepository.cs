using ParkingManager.Core.Entities;

namespace ParkingManager.Core.Interfaces
{
    public interface ISecurityRepository
    {
        Task<Security?> GetLoginByCredentials(UserLogin login);
        Task<Security?> GetByIdAsync(int id);
        Task AddAsync(Security security);
        Task UpdateAsync(Security security);
        Task DeleteAsync(int id);
    }
}