using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Services
{
    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository _tarifaRepository;

        public TarifaService(ITarifaRepository tarifaRepository)
        {
            _tarifaRepository = tarifaRepository;
        }

        /// <summary>
        /// Obtiene una lista paginada de tarifas con filtros opcionales.
        /// </summary>
        public async Task<PagedList<Tarifa>> GetTarifasAsync(TarifaQueryFilter filters)
        {
            var tarifas = await _tarifaRepository.GetTarifasAsync(filters);

            int pageNumber = filters.PageNumber == 0 ? 1 : filters.PageNumber;
            int pageSize = filters.PageSize == 0 ? 10 : filters.PageSize;

            return PagedList<Tarifa>.Create(tarifas, pageNumber, pageSize);
        }

        /// <summary>
        /// Obtiene una tarifa por su ID.
        /// </summary>
        public async Task<Tarifa?> GetTarifaByIdAsync(int id)
        {
            return await _tarifaRepository.GetTarifaByIdAsync(id);
        }

        /// <summary>
        /// Inserta una nueva tarifa.
        /// </summary>
        public async Task InsertTarifaAsync(Tarifa tarifa)
        {
            await _tarifaRepository.InsertTarifaAsync(tarifa);
        }

        /// <summary>
        /// Actualiza una tarifa existente.
        /// </summary>
        public async Task UpdateTarifaAsync(Tarifa tarifa)
        {
            await _tarifaRepository.UpdateTarifaAsync(tarifa);
        }

        /// <summary>
        /// Elimina una tarifa por ID.
        /// </summary>
        public async Task DeleteTarifaAsync(int id)
        {
            await _tarifaRepository.DeleteTarifaAsync(id);
        }
    }
}
