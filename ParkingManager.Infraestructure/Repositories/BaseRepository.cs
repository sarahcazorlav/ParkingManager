using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Interfaces;
using ParkingManager.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManager.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ParkingContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(ParkingContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _entities.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }
    }
}
