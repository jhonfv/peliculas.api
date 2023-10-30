using peliculas.utilitarios.Modelos.DTOs.Autenticacion;

namespace peliculas.negocio.Autenticacion
{
    public interface IAutenticacionNegocio
    {
        public Task<AutenticacionDTO> AutenticarServicio(string apiKey);
    }
}
