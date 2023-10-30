using Dapper;
using Microsoft.Extensions.Configuration;
using peliculas.data.Interfaces.Peliculas;
using peliculas.utilitarios.Modelos.DTOs.Peliculas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace peliculas.data.Repositorio.Peliculas
{
    public class PeliculasRepositorio : IPeliculasRepositorio
    {
        readonly IConfiguration _confg;

        public PeliculasRepositorio(IConfiguration confg)
        {
            _confg = confg;
        }

        //Este metodo debe implementar paginado para futuras funciones
        public async Task<List<PeliculasDTO>> getAllPeliculas()
        {
            var peliculas = new List<PeliculasDTO>();
            var sqlString = @"
                            SELECT TOP (100) PeliculaId
                                  ,Titulo
                                  ,Genero
                                  ,FechaLanzamiento
                                  ,FechaInserccion
                              FROM Peliculas
                            ";

            using (var dbConnection = new SqlConnection(_confg.GetConnectionString("AzureDataBase")))
            {
                var result =await  dbConnection.QueryAsync<PeliculasDTO>(sqlString);
                peliculas = result.ToList();
            }
            return peliculas;
        }

        public async Task<PeliculaDetalleDTO> getDetallePeliculaByPeliculaId(int peliculaId)
        {
            var peliculaDetalle = new PeliculaDetalleDTO();
            var sqlString = @"
                            SELECT PeliculaDetalleId
                                ,PeliculaId
                                ,Duracion
                                ,Descripcion
                                ,Actores
                            FROM PeliculasDetalles
                            WHERE peliculaId=@peliculaId
                            ";

            using (var dbConnection = new SqlConnection(_confg.GetConnectionString("AzureDataBase")))
            {
                peliculaDetalle = await dbConnection.QueryFirstOrDefaultAsync<PeliculaDetalleDTO>(sqlString, new { peliculaId });

            }
            return peliculaDetalle;
        }

        public async Task<PeliculasDTO> getPeliculaById(int peliculaId)
        {
            var pelicula = new PeliculasDTO();
            var sqlString = @"
                            SELECT PeliculaId
                                ,Titulo
                                ,Genero
                                ,FechaLanzamiento
                                ,FechaInserccion
                            FROM Peliculas
                            WHERE PeliculaId=@peliculaId
                            ";

            using (var dbConnection = new SqlConnection(_confg.GetConnectionString("AzureDataBase")))
            {
                pelicula = await dbConnection.QueryFirstOrDefaultAsync<PeliculasDTO>(sqlString, new{ peliculaId });
                
            }
            return pelicula;
        }
    }
}
