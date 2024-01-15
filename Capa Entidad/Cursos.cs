using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{

    /*Create table Cursos(
CU_CodCurso int primary key ,
CU_FechaInicio datetime default getdate(),
CU_Nombre varchar(50),
CU_Notafinal int default 0 )*/
    public class Cursos
    {

        public int CU_CodCurso { get; set; }
        public string CU_FechaInicio { get; set; }
        public String CU_Nombre { get; set; }

        public int CU_CedProf { get; set; }

        public int Control { get; set; }
       

    }
}
