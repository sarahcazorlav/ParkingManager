using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class DisponibilidadRepository : BaseRepository<Disponibilidad>, IDisponibilidadRepository
    {
        private readonly ParkingContext _context;
        private readonly DbSet<Disponibilidad> _entities;

        public DisponibilidadRepository(ParkingContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<Disponibilidad>();
        }

        public Task<IEnumerable<Disponibilidad>> GetDisponiblesPorZonaAsync(string zona)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Disponibilidad>> GetLibresAsync()
        {
            return await _entities
                .Where(d => d.Estado == "Libre")
                .ToListAsync();
        }

        public async Task<IEnumerable<Disponibilidad>> GetOcupadasAsync()
        {
            return await _entities
                .Where(d => d.Estado == "Ocupado")
                .ToListAsync();
        }
    }
}
