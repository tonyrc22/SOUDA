using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    /*PF_PFCedula int primary key,
PF_Apellido varchar(50),
PF_telefono varchar(50),
PF_Nombre varchar(50) 
)*/

    public class Encargado
    {
        public int PF_PFCedula { get; set; }
        public string PF_Apellido { get; set; }
        public string PF_telefono { get; set; }
        public string PF_Nombre { get; set; }

        public int Control { get; set; }


    }
}
