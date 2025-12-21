using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehiculoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<Vehiculo>> GetVehiculosAsync(VehiculoQueryFilter filters)
        {
            var vehiculos = await _unitOfWork.Vehiculos.GetVehiculosAsync(filters);
            var pagedList = PagedList<Vehiculo>.Create(vehiculos, filters.PageNumber, filters.PageSize);
            return pagedList;
        }

        public async Task<Vehiculo?> GetVehiculoByIdAsync(int id)
        {
            return await _unitOfWork.Vehiculos.GetVehiculoByIdAsync(id);
        }

        public async Task<Vehiculo> InsertVehiculoAsync(Vehiculo vehiculo)
        {
            await _unitOfWork.Vehiculos.InsertVehiculoAsync(vehiculo);
            await _unitOfWork.SaveChangesAsync();

            return vehiculo;
        }


        public async Task UpdateVehiculoAsync(Vehiculo vehiculo)
        {
            await _unitOfWork.Vehiculos.UpdateVehiculoAsync(vehiculo);
        }

        public async Task DeleteVehiculoAsync(int id)
        {
            await _unitOfWork.Vehiculos.DeleteVehiculoAsync(id);
        }

        Task IVehiculoService.InsertVehiculoAsync(Vehiculo vehiculo)
        {
            return InsertVehiculoAsync(vehiculo);
        }
    }
}
