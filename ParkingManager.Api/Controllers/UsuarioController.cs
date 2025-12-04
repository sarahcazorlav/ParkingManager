using Microsoft.AspNetCore.Mvc;
using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Core.Services;

namespace ParkingManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Obtiene la lista de usuarios con filtros y paginación.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetUsuarios([FromQuery] UsuarioQueryFilter filters)
        {
            // Servicio devuelve una lista paginada
            var pagedList = await _usuarioService.GetUsuariosAsync(filters);

            // Construcción de metadatos de paginación
            var pagination = new Pagination(pagedList);

            // Crear respuesta estructurada
            var response = new ResponseData<Usuario>
            {
                Data = pagedList,
                Total = pagedList.TotalCount,
                PageNumber = pagedList.CurrentPage,
                PageSize = pagedList.PageSize
            };

            // Agregamos los metadatos en los encabezados de la respuesta
            Response.Headers.Add("X-Pagination-TotalCount", pagination.TotalCount.ToString());
            Response.Headers.Add("X-Pagination-PageSize", pagination.PageSize.ToString());
            Response.Headers.Add("X-Pagination-CurrentPage", pagination.CurrentPage.ToString());
            Response.Headers.Add("X-Pagination-TotalPages", pagination.TotalPages.ToString());

            return Ok(response);
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] Usuario usuario)
        {
            await _usuarioService.InsertUsuarioAsync(usuario);
            return Ok(usuario);
        }

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutUsuario(int id, [FromBody] Usuario usuario)
        {
            usuario.Id = id;
            await _usuarioService.UpdateUsuarioAsync(usuario);
            return NoContent();
        }

        /// <summary>
        /// Elimina un usuario por ID.
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuarioService.DeleteUsuarioAsync(id);
            return NoContent();
        }
    }
}
