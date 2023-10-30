namespace peliculas.utilitarios.Modelos.DTOs.Autenticacion
{
    public class AutenticacionDTO
    {
        public string ApiKey { get; set; } = "";
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
