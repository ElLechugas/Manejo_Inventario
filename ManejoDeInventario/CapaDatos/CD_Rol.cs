using CapaEntidad; //Jeff: Importamos el espacio de nombres de la capa de entidades.
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Rol
    {
        //Jeff: Método para listar roles desde la base de datos.
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();//Jeff: Lista para almacenar los roles.
            //Jeff: Establecemos una conexión a la base de datos utilizando la cadena de conexión definida en la clase Conexion.
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    //Jeff: Construimos la consulta SQL utilizando un StringBuilder para asegurar una construcción segura de la consulta.
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdRol,Descripcion from ROL");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);// Creamos un comando SQL.
                    cmd.CommandType = CommandType.Text;//Jeff: Indicamos que el comando es de tipo texto.

                    oconexion.Open();//Jeff: Abrimos la conexión a la base de datos.

                    using (SqlDataReader dr = cmd.ExecuteReader())//Jeff: Ejecutamos el comando y obtenemos un lector de datos.
                    {
                        while (dr.Read())//Jeff: Iteramos por cada fila del resultado.
                        {
                            //Jeff: Creamos un objeto Rol y asignamos los valores de las columnas a sus propiedades.
                            lista.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Descripcion = dr["Descripcion"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Jeff: En caso de error, reiniciamos la lista.
                    lista = new List<Rol>();
                }
            }

            return lista;//Jeff: Devolvemos la lista de roles.

        }




    }
}
