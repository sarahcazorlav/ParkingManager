using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class VehiculoRepository : BaseRepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(ParkingContext context, IDapperContext dapper)
            : base(context) { }

        public async Task InsertVehiculoAsync(Vehiculo vehiculo)
        {
            await _context.Vehiculos.AddAsync(vehiculo);
        }

        public async Task UpdateVehiculoAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Update(vehiculo);
        }

        public async Task DeleteVehiculoAsync(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo != null)
                _context.Vehiculos.Remove(vehiculo);
        }

        public async Task<Vehiculo?> GetVehiculoByIdAsync(int id)
        {
            return await _context.Vehiculos.FindAsync(id);
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculosAsync(VehiculoQueryFilter filters)
        {
            var query = _context.Vehiculos.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Placa))
                query = query.Where(v => v.Placa.Contains(filters.Placa));

            return await query.ToListAsync();
        }

        public Task<IEnumerable<Vehiculo>> GetVehiculosPorUsuarioAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<Vehiculo?> GetVehiculoPorPlacaAsync(string placa)
        {
            throw new NotImplementedException();
        }
    }

}
