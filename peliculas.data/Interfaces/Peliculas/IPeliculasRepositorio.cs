using peliculas.utilitarios.Modelos.DTOs.Peliculas;

namespace peliculas.data.Interfaces.Peliculas
{
    public interface IPeliculasRepositorio
    {
        public  Task<List<PeliculasDTO>> getAllPeliculas();
        public  Task<PeliculasDTO> getPeliculaById(int peliculaId);
        public  Task<PeliculaDetalleDTO> getDetallePeliculaByPeliculaId(int peliculaId);

    }
}
