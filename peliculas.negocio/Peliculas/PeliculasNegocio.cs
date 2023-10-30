using peliculas.data.Interfaces.Peliculas;
using peliculas.utilitarios.Modelos.DTOs.Peliculas;

namespace peliculas.negocio.Peliculas
{
    public class PeliculasNegocio : IPeliculasNegocio
    {
        readonly IPeliculasRepositorio _repositorio;

        public PeliculasNegocio(IPeliculasRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<List<PeliculasDTO>> getAllPeliculas()
        {
            return _repositorio.getAllPeliculas();
        }

        public Task<PeliculasDTO> getPeliculaById(int peliculaId)
        {
            return _repositorio.getPeliculaById(peliculaId);
        }

        public Task<PeliculaDetalleDTO> getPeliculaDetalleByPeliculaId(int peliculaId)
        {
            return _repositorio.getDetallePeliculaByPeliculaId(peliculaId);
        }
    }
}
