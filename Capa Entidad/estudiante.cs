using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{

    /*create table  Estudiante (
ES_CedulaES int primary key,
ES_Nombre varchar(50),
ES_Apellido varchar(50),
ES_Telefono varchar (50),
ES_Correo varchar(50) ,
ES_Provincia varchar(50),
ES_FechaIngreso datetime default getdate(),
ES_FechaNacim datetime,
ES_SEXO varchar(20),
ES_Discap varchar (50),
ES_PadreCed int)*/
    public class estudiante
    {
        public int ES_CedulaES { get; set; }
        public String ES_Nombre { get; set; }
        public String ES_Apellido { get; set; }
        public String ES_Telefono { get; set; }
        public String ES_Correo { get; set; }
        public String ES_Provincia { get; set; }
        public String ES_FechaIngreso { get; set; }
        public String ES_FechaNacim { get; set; }
        public String ES_SEXO { get; set; }
        public String ES_Discap { get; set; }
        public int ES_PadreCed { get; set; }

        public int control { get; set; }

    }






}
