using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Infrastructure.Data;
using ParkingManager.Infrastructure.Repositories;

public class RegistroRepository
    : BaseRepository<Registro>, IRegistroRepository
{
    public RegistroRepository(ParkingContext context, IDapperContext dapper)
        : base(context) { }

    public async Task<Registro?> GetRegistroActivoPorVehiculoAsync(int vehiculoId)
    {
        return await _context.Registros
            .Include(r => r.Vehiculo)
            .Include(r => r.Espacio)
            .FirstOrDefaultAsync(r =>
                r.VehiculoId == vehiculoId &&
                r.Estado == "Activo");
    }

    public async Task<IEnumerable<Registro>> GetRegistrosActivosAsync()
    {
        return await _context.Registros
            .Where(r => r.Estado == "Activo")
            .ToListAsync();
    }
}
