using CapaDatos;// Importamos el espacio de nombres de la capa de datos.
using CapaEntidad;// Importamos el espacio de nombres de la capa de entidades.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace CapaNegocio
{
    public  class CN_Rol
    {

        private CD_Rol objcd_rol = new CD_Rol();// Instancia de la clase CD_Rol.

        // Método para listar roles desde la capa de datos.
        public List<Rol> Listar()
        {
            return objcd_rol.Listar();// Llamamos al método Listar de la capa de datos.
        }
    }
}
