using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManager.Core.Interfaces
{
    public interface IVehiculoService
    {
        Task<IEnumerable<Vehiculo>> GetVehiculosAsync(VehiculoQueryFilter filters);
        Task<Vehiculo?> GetVehiculoAsync(int id);
        Task InsertVehiculoAsync(Vehiculo vehiculo);
        Task<bool> UpdateVehiculoAsync(Vehiculo vehiculo);
        Task<bool> DeleteVehiculoAsync(int id);
    }
}
