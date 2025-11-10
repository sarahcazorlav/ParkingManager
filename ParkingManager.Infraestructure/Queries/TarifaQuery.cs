namespace ParkingManager.Infrastructure.Queries
{
    public static class TarifaQuery
    {
        // Consultar todas las tarifas
        public const string GetAllTarifas = @"
            SELECT Id, TipoVehiculo, Monto, Descripcion
            FROM Tarifas;
        ";

        // Buscar tarifa por tipo de vehículo
        public const string GetTarifaPorTipoVehiculo = @"
            SELECT TOP 1 * FROM Tarifas
            WHERE TipoVehiculo = @TipoVehiculo;
        ";

        // Tarifa activa
        public const string GetTarifasActivas = @"
            SELECT * FROM Tarifas
            WHERE Activa = 1;
        ";

        // Promedio de tarifas
        public const string GetPromedioTarifas = @"
            SELECT AVG(Monto) AS Promedio FROM Tarifas;
        ";
    }
}
