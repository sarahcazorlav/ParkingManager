using ParkingManager.Core.Entities;

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
    }
}
