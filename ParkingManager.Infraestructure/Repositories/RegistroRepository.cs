using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class ReservaRepository : BaseRepository<Registro>, IRegistroRepository
    {
        public ReservaRepository(ParkingContext context) : base(context) { }

        public Task<IEnumerable<Registro>> GetRegistrosActivosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Registro>> GetRegistrosPorUsuarioAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public async Task<(IEnumerable<Registro> reservas, int total)> GetReservasAsync(RegistroQueryFilter filters)
        {
            var query = _entities
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

        public Task RegistrarEntradaAsync(Registro registro)
        {
            throw new NotImplementedException();
        }

        public Task RegistrarSalidaAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
