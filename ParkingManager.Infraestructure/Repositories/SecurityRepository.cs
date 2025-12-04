using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly ParkingContext _context;
        private readonly IDapperContext _dapper;

        public SecurityRepository(ParkingContext context, IDapperContext dapper)
        {
            _context = context;
            _dapper = dapper;
        }

        public async Task<Security?> GetLoginByCredentials(UserLogin login)
        {
            return await _context.Securities
                .FirstOrDefaultAsync(x => x.Login == login.User);
        }

        public async Task<Security?> GetByIdAsync(int id)
        {
            return await _context.Securities.FindAsync(id);
        }

        public async Task AddAsync(Security security)
        {
            await _context.Securities.AddAsync(security);
        }

        public async Task UpdateAsync(Security security)
        {
            _context.Securities.Update(security);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var security = await GetByIdAsync(id);
            if (security != null)
            {
                _context.Securities.Remove(security);
            }
        }
    }
}