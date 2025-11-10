using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManager.Core.Interfaces
{
    public interface IDisponibilidadService
    {
        Task<IEnumerable<Disponibilidad>> GetDisponibilidadesAsync(DisponibilidadQueryFilter filters);
        Task<Disponibilidad?> GetDisponibilidadAsync(int id);
        Task InsertDisponibilidadAsync(Disponibilidad disponibilidad);
        Task<bool> UpdateDisponibilidadAsync(Disponibilidad disponibilidad);
        Task<bool> DeleteDisponibilidadAsync(int id);
    }
}
