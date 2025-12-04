using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Interfaces
{
    public interface IDisponibilidadService
    {
        Task<PagedList<Disponibilidad>> GetDisponibilidadesAsync(DisponibilidadQueryFilter filters);
        Task<Disponibilidad?> GetDisponibilidadByIdAsync(int id);
        Task InsertDisponibilidadAsync(Disponibilidad disponibilidad);
        Task UpdateDisponibilidadAsync(Disponibilidad disponibilidad);
        Task DeleteDisponibilidadAsync(int id);
    }
}