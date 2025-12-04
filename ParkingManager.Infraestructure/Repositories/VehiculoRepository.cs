using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class VehiculoRepository : BaseRepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(ParkingContext context, IDapperContext dapper) : base(context) { }

        public Task<Vehiculo?> GetVehiculoPorPlacaAsync(string placa)
        {
            throw new NotImplementedException();
        }

        public async Task<(IEnumerable<Vehiculo> vehiculos, int total)> GetVehiculosAsync(VehiculoQueryFilter filters)
        {
            var query = _entities.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Placa))
                query = query.Where(v => v.Placa.Contains(filters.Placa));

            var total = await query.CountAsync();

            var vehiculos = await query
                .Skip((filters.PageNumber - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .ToListAsync();

            return (vehiculos, total);
        }

        public Task<IEnumerable<Vehiculo>> GetVehiculosPorUsuarioAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }

        Task IVehiculoRepository.DeleteVehiculoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Vehiculo?> IVehiculoRepository.GetVehiculoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Vehiculo>> IVehiculoRepository.GetVehiculosAsync(VehiculoQueryFilter filters)
        {
            throw new NotImplementedException();
        }

        Task IVehiculoRepository.InsertVehiculoAsync(Vehiculo vehiculo)
        {
            throw new NotImplementedException();
        }

        Task IVehiculoRepository.UpdateVehiculoAsync(Vehiculo vehiculo)
        {
            throw new NotImplementedException();
        }
    }
}
