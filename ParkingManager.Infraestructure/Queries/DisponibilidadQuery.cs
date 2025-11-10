using System;
using System.Collections.Generic;
namespace ParkingManager.Infrastructure.Queries
{
    public static class DisponibilidadQuery
    {
        // Consulta básica
        public const string GetAllEspacios = @"
            SELECT Id, NumeroEspacio, Disponible, Nivel
            FROM Disponibilidades;
        ";

        // Espacios disponibles
        public const string GetEspaciosDisponibles = @"
            SELECT * FROM Disponibilidades
            WHERE Disponible = 1;
        ";

        // Espacios ocupados
        public const string GetEspaciosOcupados = @"
            SELECT * FROM Disponibilidades
            WHERE Disponible = 0;
        ";

        // Por nivel
        public const string GetDisponibilidadPorNivel = @"
            SELECT Nivel, COUNT(*) AS Total, SUM(CASE WHEN Disponible = 1 THEN 1 ELSE 0 END) AS Libres
            FROM Disponibilidades
            GROUP BY Nivel;
        ";
    }
}
