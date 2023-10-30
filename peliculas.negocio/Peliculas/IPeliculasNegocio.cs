using peliculas.utilitarios.Modelos.DTOs.Peliculas;

namespace peliculas.negocio.Peliculas
{
    public interface IPeliculasNegocio
    {
        public Task<List<PeliculasDTO>> getAllPeliculas();
        public Task<PeliculasDTO> getPeliculaById(int peliculaId);
        public Task<PeliculaDetalleDTO> getPeliculaDetalleByPeliculaId(int peliculaId);
    }
}
