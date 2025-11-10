namespace ParkingManager.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IDisponibilidadRepository Disponibilidades { get; }
        IRegistroRepository Registros { get; }
        ITarifaRepository Tarifas { get; }
        IUsuarioRepository Usuarios { get; }
        IVehiculoRepository Vehiculos { get; }

        Task<int> SaveChangesAsync();
    }
}
