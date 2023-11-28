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
    public class CD_RespuestaCliente
    {
        public List<RespuestaCliente> Listar(int idLL)
        {
            List<RespuestaCliente> lista = new List<RespuestaCliente>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT rc.Id AS IdRespuestaCliente,rc.FechaEncuesta,rp.Id AS IdRespuestaPosible FROM Llamada l");
                    query.AppendLine("INNER JOIN RespuestaCliente rc ON l.Id = rc.IdLlamada");
                    query.AppendLine("INNER JOIN RespuestaPosible rp ON rp.Id = rc.IdRespuestaPosible");
                    query.AppendLine("WHERE rc.IdLlamada = @idLL");


                    //string query = "select DescripcionOperador,DetalleEncuesta,Duracion,EncuestaEnviada from Llamada";

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@idLL", idLL);

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            lista.Add(new RespuestaCliente()
                            {
                                IdRc = int.Parse(reader["IdRespuestaCliente"].ToString()),
                                fechaEncuesta = DateTime.Parse(reader["FechaEncuesta"].ToString()),
                                respuestaPosible = new RespuestaPosible() { IdRespos = int.Parse(reader["IdRespuestaPosible"].ToString()) }

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<RespuestaCliente>();
                }
            }
            return lista;
        }
    }
}
