using peliculas.data.Interfaces.Autenticacion;
using peliculas.utilitarios.Modelos.DTOs.Autenticacion;

namespace peliculas.negocio.Autenticacion
{
    public class AutenticacionNegocio : IAutenticacionNegocio
    {
        readonly IAutenticacionRepositorio _Repositorio;

        public AutenticacionNegocio(IAutenticacionRepositorio repositorio)
        {
            _Repositorio = repositorio;
        }

        public async Task<AutenticacionDTO> AutenticarServicio(string apiKey)
        {
           return await _Repositorio.AutenticarServicio(apiKey);
            
        }
    }
}
