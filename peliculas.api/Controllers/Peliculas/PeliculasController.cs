using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using peliculas.negocio.Peliculas;
using peliculas.utilitarios.Modelos.DTOs.Peliculas;

namespace peliculas.api.Controllers.Peliculas
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        #region ctor
        
        readonly IPeliculasNegocio _negocio;
        public PeliculasController(IPeliculasNegocio negocio)
        {
            _negocio = negocio;
        }
        #endregion

        /// <summary>
        /// Obtener todo el listado de peliculas
        /// </summary>
        /// <returns>List<PeliculasDTO></PeliculasDTO></returns>
        [HttpGet("/GetAllPeliculas")]
        public async Task<IActionResult> GetAllPeliculas()
        {
            var peliculas =await _negocio.getAllPeliculas();
            return Ok(peliculas);
        }

        /// <summary>
        /// Obtener la informacion de una pelicula en espefico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PeliculaDetalleDTO</returns>
        [HttpGet("/GetPeliculaById")]
        public async Task<IActionResult> GetPeliculaById(int peliculaId)
        {
            var pelicula = await _negocio.getPeliculaById(peliculaId);
            if(pelicula is null)
            {
                return NotFound($"Error, la pelicula {peliculaId} no existe.");
            }
            else
            {
                return Ok(pelicula);
            }
        }

        [HttpGet("/GetPeliculaDetalle")]
        public async Task<IActionResult> GetPeliculaDetalle(int peliculaId)
        {
            var peliculaDetalle = await _negocio.getPeliculaDetalleByPeliculaId(peliculaId);
            if (peliculaDetalle is null)
            {
                return NotFound($"Error al obtener detalles, la pelicula {peliculaId} no existe.");
            }
            else
            {
                return Ok(peliculaDetalle);
            }
        }

    }
}
