using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Interfaces
{
    public interface IVehiculoRepository : IBaseRepository<Vehiculo>
    {
        Task<IEnumerable<Vehiculo>> GetAllAsync();
        Task<IEnumerable<Vehiculo>> GetVehiculosPorUsuarioAsync(int usuarioId);
        Task<Vehiculo?> GetVehiculoPorPlacaAsync(string placa);
        Task<Vehiculo?> GetByIdAsync(int id);
        Task AddAsync(Vehiculo vehiculo);
        Task UpdateAsync(Vehiculo vehiculo);
        Task DeleteAsync(int id);
        Task<IEnumerable<Vehiculo>> GetVehiculosAsync(VehiculoQueryFilter filters);
        Task<Vehiculo?> GetVehiculoByIdAsync(int id);
        Task InsertVehiculoAsync(Vehiculo vehiculo);
        Task UpdateVehiculoAsync(Vehiculo vehiculo);
        Task DeleteVehiculoAsync(int id);
    }
}
