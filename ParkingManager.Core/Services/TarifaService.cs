using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Services
{
    public class TarifaService : ITarifaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TarifaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<Tarifa>> GetTarifasAsync(TarifaQueryFilter filters)
        {
            var tarifas = await _unitOfWork.Tarifas.GetTarifasAsync(filters);
            var pagedList = PagedList<Tarifa>.Create(tarifas, filters.PageNumber, filters.PageSize);
            return pagedList;
        }

        public async Task<Tarifa?> GetTarifaByIdAsync(int id)
        {
            return await _unitOfWork.Tarifas.GetTarifaByIdAsync(id);
        }

        public async Task InsertTarifaAsync(Tarifa tarifa)
        {
            await _unitOfWork.Tarifas.InsertTarifaAsync(tarifa);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Tarifa> CrearAsync(Tarifa tarifa)
        {
            tarifa.FechaCreacion = DateTime.UtcNow;

            await _unitOfWork.Tarifas.AddAsync(tarifa);

            await _unitOfWork.SaveChangesAsync();

            return tarifa;
        }

        public async Task<Tarifa> CrearTarifaAsync(Tarifa tarifa)
        {
            tarifa.FechaCreacion = DateTime.UtcNow;

            await _unitOfWork.Tarifas.AddAsync(tarifa);

            await _unitOfWork.SaveChangesAsync();

            return tarifa;
        }

        public async Task UpdateTarifaAsync(Tarifa tarifa)
        {
            await _unitOfWork.Tarifas.UpdateTarifaAsync(tarifa);
        }

        public async Task DeleteTarifaAsync(int id)
        {
            await _unitOfWork.Tarifas.DeleteTarifaAsync(id);
        }
    }
}