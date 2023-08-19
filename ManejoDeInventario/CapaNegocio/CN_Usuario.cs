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
           

        

    }
}
