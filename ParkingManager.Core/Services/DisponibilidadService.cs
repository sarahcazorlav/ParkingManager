using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Services
{
    public class DisponibilidadService : IDisponibilidadService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DisponibilidadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<Disponibilidad>> GetDisponibilidadesAsync(DisponibilidadQueryFilter filters)
        {
            var disponibilidades = await _unitOfWork.Disponibilidades.GetDisponibilidadesAsync(filters);
            var pagedList = PagedList<Disponibilidad>.Create(disponibilidades, filters.PageNumber, filters.PageSize);
            return pagedList;
        }

        public async Task<Disponibilidad?> GetDisponibilidadByIdAsync(int id)
        {
            return await _unitOfWork.Disponibilidades.GetDisponibilidadByIdAsync(id);
        }

        public async Task InsertDisponibilidadAsync(Disponibilidad disponibilidad)
        {
            await _unitOfWork.Disponibilidades.InsertDisponibilidadAsync(disponibilidad);
        }

        public async Task UpdateDisponibilidadAsync(Disponibilidad disponibilidad)
        {
            await _unitOfWork.Disponibilidades.UpdateDisponibilidadAsync(disponibilidad);
        }

        public async Task DeleteDisponibilidadAsync(int id)
        {
            await _unitOfWork.Disponibilidades.DeleteDisponibilidadAsync(id);
        }
    }
}