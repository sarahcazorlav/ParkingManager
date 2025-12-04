using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Interfaces
{
    public interface IVehiculoService
    {
        Task<PagedList<Vehiculo>> GetVehiculosAsync(VehiculoQueryFilter filters);
        Task<Vehiculo?> GetVehiculoByIdAsync(int id);
        Task InsertVehiculoAsync(Vehiculo vehiculo);
        Task UpdateVehiculoAsync(Vehiculo vehiculo);
        Task DeleteVehiculoAsync(int id);
    }
}