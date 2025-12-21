using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Interfaces
{
    public interface IRegistroRepository : IBaseRepository<Registro>
    {
        Task<Registro?> GetRegistroActivoPorVehiculoAsync(int vehiculoId);
        Task<IEnumerable<Registro>> GetRegistrosActivosAsync();
    }
}
