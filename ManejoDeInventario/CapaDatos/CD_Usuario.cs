using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;//Jeff: Importamos el espacio de nombres para trabajar con SQL Server.
using CapaEntidad; // Jeff: Importamos el espacio de nombres de la capa de entidades.
using System.Net.Configuration;

namespace CapaDatos
{
    public class CD_Usuario
    {
        // Jeff: Método para listar usuarios desde la base de datos.
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();//Jeff:  Lista para almacenar los usuarios.
            // Jeff: Establecemos una conexión a la base de datos utilizando la cadena de conexión definida en la clase Conexion.
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select IdUsuario,Documento,NombreCompleto,Correo,Clave,Estado from usuario";
                    SqlCommand cmd = new SqlCommand(query, oconexion);//Jeff:  Creamos un comando SQL.
                    cmd.CommandType = CommandType.Text;// Jeff: Indicamos que el comando es de tipo texto.
                    oconexion.Open();//Jeff:  Abrimos la conexión a la base de datos.

                    using (SqlDataReader dr = cmd.ExecuteReader()) //Jeff:  Ejecutamos el comando y obtenemos un lector de datos.
                    {
                        while (dr.Read()) // Jeff: Iteramos por cada fila del resultado.
                        {
                            //Jeff:  Creamos un objeto Usuario y asignamos los valores de las columnas a sus propiedades.
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }


                    }
                }
                catch (Exception ex)
                {
                    //Jeff:  En caso de error, mostramos un mensaje y reiniciamos la lista.
                    Console.WriteLine("Error en CD_Usuario.Listar(): " + ex.ToString());
                    lista = new List<Usuario>();
                }
            }


            return lista;//Jeff:  Devolvemos la lista de usuarios.
        }
    }
}
