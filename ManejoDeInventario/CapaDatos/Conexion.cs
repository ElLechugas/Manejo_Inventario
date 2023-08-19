using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;// Jeff:Importamos el espacio de nombres para trabajar con configuraciones.

namespace CapaDatos
{
    public class Conexion
    {
        //Jeff:Definimos una propiedad estática para almacenar la cadena de conexión.
        public static string cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();
        //Jeff: ConfigurationManager nos permite acceder a las configuraciones de la aplicación.
        //Jeff:Estamos buscando la cadena de conexión con la clave "cadena_conexion".
    }
}
