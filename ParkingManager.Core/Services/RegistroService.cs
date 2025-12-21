using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Registro> RegistrarEntradaAsync(Registro registro)
        {
            // Validar si el vehículo ya tiene un registro activo
            var activo = await _unitOfWork.Registros
                .GetRegistroActivoPorVehiculoAsync(registro.VehiculoId);

            if (activo != null)
                throw new Exception("El vehículo ya tiene un registro activo");

            //Setear valores iniciales
            registro.FechaEntrada = DateTime.UtcNow;
            registro.Estado = "Activo";

            // Insertar
            await _unitOfWork.Registros.AddAsync(registro);
            await _unitOfWork.SaveChangesAsync();

            return registro;
        }

        public async Task<Registro> RegistrarSalidaAsync(int registroId)
        {
            var registro = await _unitOfWork.Registros.GetByIdAsync(registroId);

            if (registro == null)
                throw new Exception("Registro no encontrado");

            registro.FechaSalida = DateTime.UtcNow;
            registro.Estado = "Finalizado";

            registro.TiempoEstadia =
                (int)(registro.FechaSalida.Value - registro.FechaEntrada).TotalMinutes;

            await _unitOfWork.SaveChangesAsync();

            return registro;
        }

        public async Task<Registro?> GetRegistroByIdAsync(int id)
        {
            return await _unitOfWork.Registros.GetByIdAsync(id);
        }
    }


}