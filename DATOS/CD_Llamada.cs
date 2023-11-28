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
    public class CD_Llamada
    {
        public List<Llamada> Listar()
        {
            List<Llamada> lista = new List<Llamada>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT l.Id, l.DescripcionOperador, l.DetalleEncuesta, l.Duracion, l.EncuestaEnviada, l.DniCliente,");
                    query.AppendLine("c.Id AS CambioEstadoId, c.FechaHoraInicio, rc.Id AS RespuestaClienteId,rc.FechaEncuesta");
                    query.AppendLine("FROM Llamada l");
                    query.AppendLine("INNER JOIN CambioEstado c ON l.Id = c.IdLlamada");
                    query.AppendLine("INNER JOIN Cliente cli ON cli.Dni = l.DniCliente");
                    query.AppendLine("INNER JOIN RespuestaCliente rc ON rc.IdLlamada = l.Id");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int llamadaId = Convert.ToInt32(reader["Id"]);
                            Llamada llamada = lista.Find(e => e.Idll == llamadaId);

                            if (llamada == null)
                            {
                                llamada = new Llamada
                                {
                                    Idll = llamadaId,
                                    descripcionOperador = reader["DescripcionOperador"].ToString(),
                                    detalleEncuesta = reader["DetalleEncuesta"].ToString(),
                                    duracion = int.Parse(reader["Duracion"].ToString()),
                                    encuestaEnviada = bool.Parse(reader["EncuestaEnviada"].ToString()),
                                    cliente = new Cliente { dni = reader["DniCliente"].ToString()},
                                    cambiosEstados = new List<CambioEstado>(),
                                    respuestaDeEncuesta = new List<RespuestaCliente>()
                                };

                                lista.Add(llamada);
                            }

                            if (reader["CambioEstadoId"] != DBNull.Value)
                            {
                                CambioEstado cambioEstado = new CambioEstado
                                {
                                    IdCam = Convert.ToInt32(reader["CambioEstadoId"]),
                                    //fechaHoraInicio = Convert.ToDateTime(reader["FechaHoraInicio"])
                                };

                                llamada.cambiosEstados.Add(cambioEstado);
                            }
                            if (reader["RespuestaClienteId"] != DBNull.Value)
                            {
                                int respuestaClienteId = Convert.ToInt32(reader["RespuestaClienteId"]);

                                // Verificar si ya existe una respuesta con el mismo ID
                                if (!llamada.respuestaDeEncuesta.Any(r => r.IdRc == respuestaClienteId))
                                {
                                    RespuestaCliente respuestacliente = new RespuestaCliente
                                    {
                                        IdRc = respuestaClienteId,
                                        fechaEncuesta = Convert.ToDateTime(reader["FechaEncuesta"])
                                    };

                                    llamada.respuestaDeEncuesta.Add(respuestacliente);
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Llamada>();
                }
            }
            return lista;
        }
    }
}