namespace peliculas.utilitarios.Modelos.DTOs.Peliculas
{
    public class PeliculaDetalleDTO
    {
        public int peliculaId { get; set; }
        public int duracion { get; set; }
        public string descripcion { get; set; } = "";
        public string actores { get; set; }= "";
    }
}
