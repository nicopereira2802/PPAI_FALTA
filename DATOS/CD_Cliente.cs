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
    public class CD_Cliente
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select Dni,NroCelular,NombreCompleto from Cliente";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                dni = reader["Dni"].ToString(),
                                nroCelular = reader["NroCelular"].ToString(),
                                nombreCompleto = reader["NombreCompleto"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Cliente>();
                }
            }
            return lista;
        }

        public Cliente ObtenerCliente(string documento)
        {
            Cliente cliente = null;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT Dni, NroCelular, NombreCompleto FROM Cliente WHERE Dni = @documento";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@documento", documento);

                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente()
                            {
                                dni = reader["Dni"].ToString(),
                                nroCelular = reader["NroCelular"].ToString(),
                                nombreCompleto = reader["NombreCompleto"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de la excepción
                    cliente = null;
                }
            }
            return cliente;
        }

    }
}
