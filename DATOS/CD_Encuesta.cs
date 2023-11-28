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
    public class CD_Encuesta
    {
        public Encuesta ObtenerEncuesta(int idE)
        {
            Encuesta encuesta = null;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT e.Id as IDEnc,e.Descripcion,p.Id AS idPregu FROM Encuesta e");
                    query.AppendLine("INNER JOIN Pregunta p ON e.Id = p.IdEncuesta");
                    query.AppendLine("WHERE e.Id = @idE");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idE", idE);

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (encuesta == null)
                            {
                                encuesta = new Encuesta()
                                {
                                    idEnc = int.Parse(reader["IDEnc"].ToString()),
                                    descripcion = reader["Descripcion"].ToString(), 
                                    pregunta = new List<Pregunta>(),
                                };
                            }

                            // Solo agregar respuestas posibles si hay valores en las columnas correspondientes
                            if (reader["idPregu"] != DBNull.Value)
                            {
                                Pregunta pregunta = new Pregunta()
                                {
                                    iDPreg = int.Parse(reader["idPregu"].ToString())

                                };

                                encuesta.pregunta.Add(pregunta);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de la excepción
                    encuesta = null;
                }
            }
            return encuesta;
        }
    }
}
