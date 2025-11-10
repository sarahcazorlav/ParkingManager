using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Infrastructure.Data;
using ParkingManager.Core.Interfaces;

namespace ParkingManager.Infrastructure.Repositories
{
    public class VehiculoRepository : BaseRepository<Vehiculo>
    {
        public VehiculoRepository(ParkingContext context) : base(context) { }

        public async Task<(IEnumerable<Vehiculo> vehiculos, int total)> GetVehiculosAsync(VehiculoQueryFilter filters)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Placa))
                query = query.Where(v => v.Placa.Contains(filters.Placa));

            var total = await query.CountAsync();

            var vehiculos = await query
                .Skip((filters.PageNumber - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .ToListAsync();

            return (vehiculos, total);
        }
    }
}
