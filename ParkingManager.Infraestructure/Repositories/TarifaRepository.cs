using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class TarifaRepository : BaseRepository<Tarifa>, ITarifaRepository
    {
        public TarifaRepository(ParkingContext context, IDapperContext dapper) : base(context) { }

        public Task DeleteTarifaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tarifa?> GetTarifaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tarifa?> GetTarifaPorTipoVehiculoAsync(string tipoVehiculo)
        {
            throw new NotImplementedException();
        }

        public async Task<(IEnumerable<Tarifa> tarifas, int total)> GetTarifasAsync(TarifaQueryFilter filters)
        {
            var query = _entities.AsQueryable();

            var total = await query.CountAsync();

            var tarifas = await query
                .Skip((filters.PageNumber - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .ToListAsync();

            return (tarifas, total);
        }

        public Task InsertTarifaAsync(Tarifa tarifa)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTarifaAsync(Tarifa tarifa)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Tarifa>> ITarifaRepository.GetTarifasAsync(TarifaQueryFilter filters)
        {
            throw new NotImplementedException();
        }
    }
}
