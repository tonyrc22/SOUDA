using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class NuevaMatricula
    {
        public int CU_CodCurso { get; set; }

        public string CU_FechaInicio { get; set; }

        public string CU_Nombre { get; set; }

        public string PR_Nombre { get; set; }

        public int Control { get; set; }


    }

    public class MatriculaNueva {

        public string MA_SEDE { get; set; }
        public int MA_CedulaES { get; set; }
        public int MA_CodCurso { get; set; }

        public int MA_USCedula { get; set; }

        public int Control { get; set; }


    }







}
