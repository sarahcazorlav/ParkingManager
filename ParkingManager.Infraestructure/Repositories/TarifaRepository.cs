using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class TarifaRepository : BaseRepository<Tarifa>, ITarifaRepository
    {
        private readonly ParkingContext _context;

        public TarifaRepository(ParkingContext context)
              : base(context)
        {
            _context = context;
        }

        // Agrega este constructor a la clase TarifaRepository
        public TarifaRepository(ParkingContext context, IDapperContext dapper) : base(context)
        {
            _context = context;
            // Si necesitas usar dapper, guárdalo en un campo privado
            // _dapper = dapper;
        }


        public async Task AddAsync(Tarifa tarifa)
        {
            await _context.Tarifas.AddAsync(tarifa);
        }

        public async Task InsertTarifaAsync(Tarifa tarifa)
        {
            await _context.Tarifas.AddAsync(tarifa);
        }

        public async Task UpdateTarifaAsync(Tarifa tarifa)
        {
            _context.Tarifas.Update(tarifa);
            await Task.CompletedTask;
        }

        public async Task DeleteTarifaAsync(int id)
        {
            var tarifa = await _context.Tarifas.FindAsync(id);
            if (tarifa != null)
                _context.Tarifas.Remove(tarifa);
        }

        public async Task<Tarifa?> GetTarifaPorTipoVehiculoAsync(string tipoVehiculo)
        {
            return await _context.Tarifas
                .FirstOrDefaultAsync(t => t.TipoVehiculo == tipoVehiculo && t.Activo);
        }

        public async Task<Tarifa?> GetTarifaByIdAsync(int id)
        {
            return await _context.Tarifas.FindAsync(id);
        }

        public async Task<IEnumerable<Tarifa>> GetTarifasAsync(TarifaQueryFilter filters)
        {
            var query = _context.Tarifas.AsQueryable();

            if (filters is not null)
            {
                if (!string.IsNullOrWhiteSpace(filters.TipoVehiculo))
                    query = query.Where(t => t.TipoVehiculo == filters.TipoVehiculo);

                if (filters.Activo.HasValue)
                    query = query.Where(t => t.Activo == filters.Activo.Value);

                if (filters.PageSize > 0)
                {
                    var pageNumber = filters.PageNumber <= 0 ? 1 : filters.PageNumber;
                    query = query.Skip((pageNumber - 1) * filters.PageSize)
                                 .Take(filters.PageSize);
                }
            }

            return await query.ToListAsync();
        }
    }

}
