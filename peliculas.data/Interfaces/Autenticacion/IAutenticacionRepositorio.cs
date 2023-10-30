using peliculas.utilitarios.Modelos.DTOs.Autenticacion;

namespace peliculas.data.Interfaces.Autenticacion
{
    public interface IAutenticacionRepositorio
    {
        public Task<AutenticacionDTO> AutenticarServicio(string apiKey);
    }
}
