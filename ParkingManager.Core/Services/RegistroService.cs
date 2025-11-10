using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Infrastructure.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly IRegistroRepository _registroRepository;

        public RegistroService(IRegistroRepository registroRepository)
        {
            _registroRepository = registroRepository;
        }

        public async Task<IEnumerable<Registro>> GetRegistrosAsync(RegistroQueryFilter filters)
        {
            var registros = await _registroRepository.GetAllAsync();

            if (filters.VehiculoId.HasValue)
                registros = registros.Where(r => r.VehiculoId == filters.VehiculoId);

            if (filters.FechaEntrada.HasValue)
                registros = registros.Where(r => r.FechaEntrada.Date == filters.FechaEntrada.Value.Date);

            return registros;
        }

        public async Task<Registro?> GetRegistroAsync(int id) => await _registroRepository.GetByIdAsync(id);

        public async Task InsertRegistroAsync(Registro registro) => await _registroRepository.AddAsync(registro);

        public Task<bool> UpdateRegistroAsync(Registro registro)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRegistroAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
