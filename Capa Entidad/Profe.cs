using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{

    /*PR_CedProf int primary key ,
PR_Nombre varchar(50),
PR_Apellido varchar(50),
PR_FechaIngreso datetime default getdate(),

)*/
    public class Profesor
    {
        public int PR_CedProf { get; set; }
        public string PR_Nombre { get; set; }
        public string PR_Apellido { get; set; }
        public string PR_FechaIngreso { get; set; }

        public string PR_Telefono { get; set; }
        public int Control { get; set; }

    }
}
