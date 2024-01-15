using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class EstudianteXEncargado
    {


        public int ES_CedulaES { get; set; }
        public string ES_Nombre { get; set; }
        public string ES_Apellido { get; set; }
        public string ES_Telefono { get; set; }
        public int PF_PFCedula { get; set; }
        public string PF_Apellido { get; set; }
        public string PF_telefono { get; set; }
        public string PF_Nombre { get; set; }

        public int control { get; set; }
    }
}
