using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CursoXProfesor
    {


        public int CU_CodCurso { get; set; }
        public string CU_FechaInicio { get; set; }
        public string CU_Nombre { get; set; }

        public int PR_CedProf { get; set; }
        public string PR_Nombre { get; set; }
        public string PR_FechaIngreso { get; set; }
        public string PR_Telefono { get; set; }

        public int control { get; set; }
    }
}
