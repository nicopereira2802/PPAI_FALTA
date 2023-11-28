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
    public class CD_CambioEstado
    {
        
        public List<CambioEstado> Listar(int idLlamada)
        {
            List<CambioEstado> lista = new List<CambioEstado>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT c.FechaHoraInicio,e.Id FROM CambioEstado c");
                    query.AppendLine("INNER JOIN Estado e ON c.IdEstado = e.Id");
                    query.AppendLine("WHERE c.IdLlamada = @IdLlamada");


                    //string query = "select DescripcionOperador,DetalleEncuesta,Duracion,EncuestaEnviada from Llamada";

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@IdLlamada", idLlamada);

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            lista.Add(new CambioEstado()
                            {
                                IdCam = int.Parse(reader["Id"].ToString()),
                                fechaHoraInicio = DateTime.Parse(reader["FechaHoraInicio"].ToString()),
                            
                                estado = new Estado() {  IdEst = int.Parse(reader["Id"].ToString()) }

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<CambioEstado>();
                }
            }
            return lista;
        }
        /*
        public CambioEstado ObtenerPorId(int idCambioEstado)
        {
            CambioEstado cambioEstado = null;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT c.FechaHoraInicio, e.Id FROM CambioEstado c");
                    query.AppendLine("INNER JOIN Estado e ON c.IdEstado = e.Id");
                    query.AppendLine("WHERE c.Id = @IdCambioEstado");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    // Agregar el parámetro
                    cmd.Parameters.AddWithValue("@IdCambioEstado", idCambioEstado);

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cambioEstado = new CambioEstado()
                            {
                                fechaHoraInicio = DateTime.Parse(reader["FechaHoraInicio"].ToString()),
                                estado = new Estado() { nombre = reader["Id"].ToString() }
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones, puedes registrar o lanzar la excepción según tus necesidades.
                }
            }

            return cambioEstado;
        }*/
    }

    
}
