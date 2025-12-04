using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class DisponibilidadRepository : BaseRepository<Disponibilidad>, IDisponibilidadRepository
    {
        private readonly ParkingContext _context;
        private readonly DbSet<Disponibilidad> _entities;

        public DisponibilidadRepository(ParkingContext context, IDapperContext dapper) : base(context)
        {
            _context = context;
            _entities = context.Set<Disponibilidad>();
        }

        public async Task<IEnumerable<Disponibilidad>> GetDisponibilidadesAsync(DisponibilidadQueryFilter filter)
        {
            var query = _entities.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Zona))
                query = query.Where(x => x.Zona == filter.Zona);

            if (!string.IsNullOrEmpty(filter.Estado))
                query = query.Where(x => x.Estado == filter.Estado);

            return await query.ToListAsync();
        }

        public async Task<Disponibilidad?> GetDisponibilidadByIdAsync(int id)
        {
            return await _entities.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task InsertDisponibilidadAsync(Disponibilidad disponibilidad)
        {
            await _entities.AddAsync(disponibilidad);
        }

        public async Task UpdateDisponibilidadAsync(Disponibilidad disponibilidad)
        {
            _entities.Update(disponibilidad);
            await Task.CompletedTask;
        }

        public async Task DeleteDisponibilidadAsync(int id)
        {
            var entity = await GetDisponibilidadByIdAsync(id);
            if (entity != null)
                _entities.Remove(entity);
        }

        public async Task<IEnumerable<Disponibilidad>> GetLibresAsync()
        {
            return await _entities
                .Where(d => d.Estado == "Libre")
                .ToListAsync();
        }

        Task<IEnumerable<Disponibilidad>> IDisponibilidadRepository.GetDisponiblesPorZonaAsync(string zona)
        {
            throw new NotImplementedException();
        }
    }
}
