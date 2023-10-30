using Dapper;
using Microsoft.Extensions.Configuration;
using peliculas.data.Interfaces.Autenticacion;
using peliculas.utilitarios.Modelos.DTOs.Autenticacion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace peliculas.data.Repositorio.Autenticacion
{
    public class AutenticacionRepositorio:IAutenticacionRepositorio
    {
        readonly IConfiguration _config;

        public AutenticacionRepositorio(IConfiguration config)
        {
            _config = config;
        }

        public async Task<AutenticacionDTO> AutenticarServicio(string apiKey)
        {
            var apiKeyObj = new AutenticacionDTO();
            var sqlString = @"
                                SELECT ApiKey, Estado
                                FROM ApiKeys
                                WHERE Apikey=@apiKey";
            using(var dbConnection = new SqlConnection(_config.GetConnectionString("AzureDataBase")))
            {

                apiKeyObj = await dbConnection.QueryFirstOrDefaultAsync<AutenticacionDTO>(sqlString,new{apiKey});
            }
            return apiKeyObj;
        }
    }
}
