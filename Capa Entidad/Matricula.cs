using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    /*create table Matricula(
MA_Transac int primary key identity,
MA_SEDE varchar(50),
MA_CedulaES int ,
MA_CodCurso int ,
MA_PFCedula int ,
MA_USCedula int ,
MA_CedProf int ,
)*/

    /*VER VIDEO 4 !*/
    public class Matricula
    {
        public int MA_Transac { get; set; }
        public string MA_SEDE { get; set; }
        public int MA_CedulaES { get; set; }
        public int MA_CodCurso { get; set; }
        public int PF_PFCedula { get; set; }
        public int MA_USCedula { get; set; }
        public int MA_CedProf { get; set; }

        public string ES_Nombre { get; set; }
        public string CU_Nombre { get; set; }
        public string PR_Nombre { get; set; }
        public string PF_Nombre { get; set; }
        public string US_Nombre { get; set; }

        public string MA_Fecha { get; set; }

        public string CU_FechaInicio { get; set; }


        public int Control { get; set; }

    }
}
