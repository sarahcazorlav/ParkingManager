using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingManager.Core.Services
{
    public class DisponibilidadService : IDisponibilidadService
    {
        private readonly IDisponibilidadRepository _disponibilidadRepository;

        public DisponibilidadService(IDisponibilidadRepository disponibilidadRepository)
        {
            _disponibilidadRepository = disponibilidadRepository;
        }

        public async Task<IEnumerable<Disponibilidad>> GetDisponibilidadesAsync(DisponibilidadQueryFilter filters)
        {
            var disponibilidades = await _disponibilidadRepository.GetAllAsync();

            if (filters.Disponible.HasValue)
                disponibilidades = disponibilidades.Where(d => d.Disponible == filters.Disponible);

            if (!string.IsNullOrEmpty(filters.Sector))
                disponibilidades = disponibilidades.Where(d => d.Zona.Contains(filters.Sector));

            return disponibilidades;
        }

        public async Task<Disponibilidad?> GetDisponibilidadAsync(int id) => await _disponibilidadRepository.GetByIdAsync(id);

        public async Task InsertDisponibilidadAsync(Disponibilidad disponibilidad) => await _disponibilidadRepository.AddAsync(disponibilidad);

        public Task<bool> UpdateDisponibilidadAsync(Disponibilidad disponibilidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDisponibilidadAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
