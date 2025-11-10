namespace ParkingManager.Infrastructure.Queries
{
    public static class RegistroQuery
    {
        // Listar todos los registros
        public const string GetAllRegistros = @"
            SELECT r.Id, v.Placa, r.FechaEntrada, r.FechaSalida, t.Monto, u.Nombre AS Propietario
            FROM Registros r
            INNER JOIN Vehiculos v ON v.Id = r.VehiculoId
            INNER JOIN Usuarios u ON u.Id = v.UsuarioId
            LEFT JOIN Tarifas t ON t.Id = r.TarifaId;
        ";

        // Filtrar registros activos (vehículos dentro del estacionamiento)
        public const string GetRegistrosActivos = @"
            SELECT * FROM Registros
            WHERE FechaSalida IS NULL;
        ";

        // Historial de un vehículo
        public const string GetHistorialVehiculo = @"
            SELECT * FROM Registros
            WHERE VehiculoId = @VehiculoId
            ORDER BY FechaEntrada DESC;
        ";

        // Reporte de ingresos diarios
        public const string GetIngresosDiarios = @"
            SELECT CAST(FechaSalida AS DATE) AS Fecha, SUM(t.Monto) AS Total
            FROM Registros r
            INNER JOIN Tarifas t ON t.Id = r.TarifaId
            WHERE FechaSalida IS NOT NULL
            GROUP BY CAST(FechaSalida AS DATE)
            ORDER BY Fecha DESC;
        ";
    }
}
