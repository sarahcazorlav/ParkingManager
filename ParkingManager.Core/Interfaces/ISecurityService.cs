using ParkingManager.Core.Entities;

namespace ParkingManager.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
        Task RegisterUser(Security security);
    }
}