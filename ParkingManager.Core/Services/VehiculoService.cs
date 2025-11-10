using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingManager.Infrastructure.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculosAsync(VehiculoQueryFilter filters)
        {
            var vehiculos = await _vehiculoRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(filters.Placa))
                vehiculos = vehiculos.Where(v => v.Placa.Contains(filters.Placa));

            if (filters.UsuarioId.HasValue)
                vehiculos = vehiculos.Where(v => v.UsuarioId == filters.UsuarioId);

            return vehiculos;
        }

        public async Task<Vehiculo?> GetVehiculoAsync(int id) => await _vehiculoRepository.GetByIdAsync(id);

        public async Task InsertVehiculoAsync(Vehiculo vehiculo) => await _vehiculoRepository.AddAsync(vehiculo);

        public Task<bool> UpdateVehiculoAsync(Vehiculo vehiculo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteVehiculoAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
