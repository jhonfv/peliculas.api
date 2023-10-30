using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using peliculas.negocio.Autenticacion;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace peliculas.api.Controllers.Autenticacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        readonly IAutenticacionNegocio _negocio;
        readonly IConfiguration _configuration;

        public AutenticacionController(IAutenticacionNegocio negocio, IConfiguration configuration)
        {
            _negocio = negocio;
            _configuration = configuration;
        }

        /// <summary>
        /// Autenticar ApiKey para obtener token de acceso
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns>Token JWT</returns>
        [HttpPost]
        public async Task<IActionResult> GetToken(string apiKey)
        {
            var apiKeyObj = await _negocio.AutenticarServicio(apiKey);
            if(apiKeyObj != null && apiKeyObj.Estado)
            {
                //Token
                var token = generateToken(apiKey);
                return Ok(token);
            }
            else
            {
                return NotFound($"ApiKey {apiKey} no habilitada");
            }
        }

        internal string generateToken(string apiKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyConf = _configuration["Jwt:Key"];
            var key = Encoding.UTF8.GetBytes(keyConf);
            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,apiKey)
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDes);
            return tokenHandler.WriteToken(token);
        }
    }
}
