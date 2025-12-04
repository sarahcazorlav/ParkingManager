using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;

namespace ParkingManager.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            var security = await _unitOfWork.Security.GetLoginByCredentials(login);
            if (security == null)
            {
                throw new Exception("Credenciales inválidas");
            }
            return security;
        }

        public async Task RegisterUser(Security security)
        {
            await _unitOfWork.Security.AddAsync(security);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}