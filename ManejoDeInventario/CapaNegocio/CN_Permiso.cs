using CapaDatos;// Importamos el espacio de nombres de la capa de datos.
using CapaEntidad;// Importamos el espacio de nombres de la capa de entidades.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CapaNegocio
{
    public class CN_Permiso
    {
        private CD_Permiso objcd_permiso = new CD_Permiso();// Instancia de la clase CD_Permiso.
        // Método para listar permisos para un usuario específico desde la capa de datos.
        public List<Permiso> Listar(int idUsuario)
        {
            return objcd_permiso.Listar(idUsuario); // Llamamos al método Listar de la capa de datos.
        }
    }
}
