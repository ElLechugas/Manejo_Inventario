using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;//Jeff: Importamos el espacio de nombres de la capa de datos.
using CapaEntidad;//Jeff: Importamos el espacio de nombres de la capa de entidades.

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario= new CD_Usuario();//Jeff: Instancia de la clase CD_Usuario.
           //Jeff: Método para listar usuarios desde la capa de datos.
           public List<Usuario> Listar()
           {
            return objcd_usuario.Listar();//Jeff: Llamamos al método Listar de la capa de datos.
           }
        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del usuario\n";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario\n";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Es necesario la clave del usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.Registrar(obj, out Mensaje);
            }


        }


        public bool Editar(Usuario obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del usuario\n";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario\n";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Es necesario la clave del usuario\n";
            }


            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }


        }


        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }




    }
}
