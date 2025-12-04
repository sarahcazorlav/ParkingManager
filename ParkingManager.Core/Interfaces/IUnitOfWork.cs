using System.Data;

namespace ParkingManager.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDisponibilidadRepository Disponibilidades { get; }
        IRegistroRepository Registros { get; }
        ITarifaRepository Tarifas { get; }
        IUsuarioRepository Usuarios { get; }
        IVehiculoRepository Vehiculos { get; }
        ISecurityRepository Security { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        IDbConnection? GetDbConnection();
        IDbTransaction? GetDbTransaction();
    }
}