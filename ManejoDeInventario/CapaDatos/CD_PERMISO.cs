using CapaEntidad;//Jeff: Importamos el espacio de nombres de la capa de entidades.
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net.Configuration;



namespace CapaDatos
{
    public class CD_Permiso
    {
        //Jeff: Método para listar permisos para un usuario específico desde la base de datos.
        public List<Permiso> Listar(int idusuario)
        {
            List<Permiso> lista = new List<Permiso>();//Jeff: Lista para almacenar los permisos.
            //Jeff: Establecemos una conexión a la base de datos utilizando la cadena de conexión definida en la clase Conexion.
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    //Jeff: Construimos la consulta SQL utilizando un StringBuilder para asegurar una construcción segura de la consulta.
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.IdRol,p.NombreMenu from PERMISO p");
                    query.AppendLine("inner join ROL r on r.IdRol = p.IdRol");
                    query.AppendLine("inner join USUARIO u on u.IdRol = r.IdRol");
                    query.AppendLine("where u.IdUsuario = @idusuario");


                   
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);//Jeff: Creamos un comando SQL.
                    cmd.Parameters.AddWithValue("@idusuario", idusuario);//Jeff: Agregamos el parámetro @idusuario.
                    cmd.CommandType = CommandType.Text; //Jeff: Indicamos que el comando es de tipo texto.
                    oconexion.Open();//Jeff: Abrimos la conexión a la base de datos.

                    using (SqlDataReader dr = cmd.ExecuteReader())//Jeff: Ejecutamos el comando y obtenemos un lector de datos.
                    {
                        while (dr.Read())//Jeff: Iteramos por cada fila del resultado.
                        {
                            //Jeff: Creamos un objeto Permiso y asignamos los valores de las columnas a sus propiedades.
                            lista.Add(new Permiso()
                            {
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) },//Jeff: Creamos un objeto Rol.
                                NombreMenu = dr["NombreMenu"].ToString(),
                            });
                        }


                    }
                }
                catch (Exception ex)
                {
                    //Jeff: En caso de error, mostramos un mensaje y reiniciamos la lista.
                    Console.WriteLine("Error en CD_Usuario.Listar(): " + ex.ToString());
                    lista = new List<Permiso>();
                }
            }


            return lista;//Jeff: Devolvemos la lista de permisos.
        }
    }
}
