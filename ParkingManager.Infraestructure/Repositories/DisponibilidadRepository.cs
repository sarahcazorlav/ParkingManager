using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class DisponibilidadRepository : BaseRepository<Disponibilidad>
    {
        public DisponibilidadRepository(ParkingContext context) : base(context) { }

        public async Task<IEnumerable<Disponibilidad>> GetLibresAsync()
        {
            return await _dbSet
                .Where(d => d.Estado == "Libre")
                .ToListAsync();
        }
    }
}
