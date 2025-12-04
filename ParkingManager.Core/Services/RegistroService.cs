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

        public async Task<PagedList<Registro>> GetRegistrosAsync(RegistroQueryFilter filters)
        {
            var registros = await _unitOfWork.Registros.GetRegistrosAsync(filters);
            var pagedList = PagedList<Registro>.Create(registros, filters.PageNumber, filters.PageSize);
            return pagedList;
        }

        public async Task<Registro?> GetRegistroByIdAsync(int id)
        {
            return await _unitOfWork.Registros.GetRegistroByIdAsync(id);
        }

        public async Task InsertRegistroAsync(Registro registro)
        {
            await _unitOfWork.Registros.InsertRegistroAsync(registro);
        }

        public async Task UpdateRegistroAsync(Registro registro)
        {
            await _unitOfWork.Registros.UpdateRegistroAsync(registro);
        }

        public async Task DeleteRegistroAsync(int id)
        {
            await _unitOfWork.Registros.DeleteRegistroAsync(id);
        }
    }
}