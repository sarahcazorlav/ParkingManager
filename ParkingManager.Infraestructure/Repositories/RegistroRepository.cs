using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class ReservaRepository : BaseRepository<Registro>
    {
        public ReservaRepository(ParkingContext context) : base(context) { }

        public async Task<(IEnumerable<Registro> reservas, int total)> GetReservasAsync(RegistroQueryFilter filters)
        {
            var query = _dbSet
                .Include(r => r.Vehiculo)
                .Include(r => r.Zona)
                .AsQueryable();

            if (filters.FechaEntrada.HasValue)
                query = query.Where(r => r.Fecha >= filters.FechaEntrada.Value);

            if (filters.FechaSalida.HasValue)
                query = query.Where(r => r.Fecha <= filters.FechaSalida.Value);

            var total = await query.CountAsync();

            var reservas = await query
                .Skip((filters.PageNumber - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .ToListAsync();

            return (reservas, total);
        }
    }
}
