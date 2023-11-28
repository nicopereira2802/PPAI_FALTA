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
    public class CD_Pregunta
    {
        public Pregunta ObtenerPregunta(int idP)
        {
            Pregunta pregunta = null;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.Id as IdPreg, e.Id AS IdEncuesta, p.Pregun, rp.Id AS IdRespuestaPosible, rp.Descripcion AS RespuestaPosible");
                    query.AppendLine("FROM Pregunta p");
                    query.AppendLine("INNER JOIN Encuesta e ON p.IdEncuesta = e.Id");
                    query.AppendLine("LEFT JOIN RespuestaPosible rp ON p.Id = rp.IdPregunta");
                    query.AppendLine("WHERE p.Id = @idP");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idP", idP);

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (pregunta == null)
                            {
                                pregunta = new Pregunta()
                                {
                                    iDPreg = int.Parse(reader["IdPreg"].ToString()),
                                    descripcion = reader["Pregun"].ToString(),
                                    encuesta = new Encuesta { idEnc = int.Parse(reader["IdEncuesta"].ToString()) },
                                    respuestaP = new List<RespuestaPosible>(),
                                };
                            }

                            // Solo agregar respuestas posibles si hay valores en las columnas correspondientes
                            if (reader["IdRespuestaPosible"] != DBNull.Value)
                            {
                                RespuestaPosible respuestaPosible = new RespuestaPosible()
                                {
                                    IdRespos = int.Parse(reader["IdRespuestaPosible"].ToString())
                                   
                                };

                                pregunta.respuestaP.Add(respuestaPosible);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de la excepción
                    pregunta = null;
                }
            }
            return pregunta;
        }

    }
}
