namespace peliculas.utilitarios.Modelos.DTOs.Peliculas
{
    public class PeliculasDTO
    {
        public int peliculaId { get; set; }
        public string titulo { get; set; } = "";
        public string genero { get; set; } = "";
        public DateTime fechaLanzamiento { get; set; }
        public string? rutaImgPortada { get; set; }
    }
}
