using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Permiso
    {
        public int IdPermiso { get; set; }//Jeff: Propiedad para almacenar el ID del permiso.
        public Rol oRol { get; set; }//Jeff: Propiedad para almacenar el objeto de tipo Rol asociado al permiso.
        public string NombreMenu { get; set; }//Jeff: Propiedad para almacenar el nombre del menú asociado al permiso.
        public string FechaRegistro { get; set; }//Jeff: Propiedad para almacenar la fecha de registro del permiso.


    }
}
