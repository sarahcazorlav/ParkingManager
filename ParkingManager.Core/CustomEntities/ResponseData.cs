using System.Collections.Generic;
using System.Linq;

namespace ParkingManager.Core.CustomEntities
{
    /// <summary>
    /// Representa una respuesta genérica que puede incluir datos paginados y metainformación.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad o DTO contenido en la respuesta.</typeparam>
    public class ResponseData<T>
    {
        /// <summary>
        /// Conjunto de datos devueltos en la consulta.
        /// </summary>
        public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();

        /// <summary>
        /// Total de registros encontrados.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Número de página actual (si se aplica paginación).
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Cantidad de registros por página (si se aplica paginación).
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Cantidad total de páginas calculadas.
        /// </summary>
        public int TotalPages
        {
            get
            {
                if (PageSize == 0) return 0;
                return (int)System.Math.Ceiling(Total / (double)PageSize);
            }
        }

        /// <summary>
        /// Indica si existe una página anterior.
        /// </summary>
        public bool HasPreviousPage => PageNumber > 1;

        /// <summary>
        /// Indica si existe una página siguiente.
        /// </summary>
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
