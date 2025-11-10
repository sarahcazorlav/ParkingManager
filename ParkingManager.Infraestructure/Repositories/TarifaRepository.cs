using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class TarifaRepository : BaseRepository<Tarifa>
    {
        public TarifaRepository(ParkingContext context) : base(context) { }

        public async Task<(IEnumerable<Tarifa> tarifas, int total)> GetTarifasAsync(TarifaQueryFilter filters)
        {
            var query = _dbSet.AsQueryable();

            var total = await query.CountAsync();

            var tarifas = await query
                .Skip((filters.PageNumber - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .ToListAsync();

            return (tarifas, total);
        }
    }
}
