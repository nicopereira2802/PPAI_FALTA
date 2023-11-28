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
    public class CD_Estado
    {
        public List<Estado> Listar()
        {
            List<Estado> lista = new List<Estado>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select Nombre from Estado";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text; 

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Estado()
                            {
                                
                                nombre = reader["Nombre"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Estado>();
                }
            }
            return lista;
        }

        public Estado ListarIdCambio(int IdE)
        {
            Estado estado = null;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT Id,Nombre FROM Estado WHERE Id = @ide";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ide", IdE);

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            estado = new Estado()
                            {
                                IdEst = int.Parse(reader["Id"].ToString()),
                                nombre = reader["Nombre"].ToString(),
                                
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de la excepción
                    estado = null;
                }
            }
            return estado;
        }
    }
}
