using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ENTIDADES;

namespace DATOS
{
    public class CD_RespuestaPosible
    {
        public RespuestaPosible ObtenerRespuestaPosible(int idResPos)
        {
            RespuestaPosible respuestaposible = null;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT rp.Id AS IdResPos,rp.Valor,rp.Descripcion,p.Id AS IdPregunta");
                    query.AppendLine("FROM RespuestaPosible rp INNER JOIN Pregunta p ON rp.IdPregunta  = p.Id");
                    query.AppendLine("WHERE  rp.Id = @idResPos");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idResPos", idResPos);

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            respuestaposible = new RespuestaPosible()
                            {
                                IdRespos = int.Parse(reader["IdResPos"].ToString()),
                                valor = int.Parse(reader["Valor"].ToString()),
                                descripcion = reader["Descripcion"].ToString(),
                                pregunta = new Pregunta { iDPreg = int.Parse(reader["IdPregunta"].ToString()) },
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de la excepción
                    respuestaposible = null;
                }
            }
            return respuestaposible;
        }
    }
}
