using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{

    /*US_USCedula int primary key ,
US_Nombre varchar(50),
US_Apellido varchar(50),
US_Ingreso datetime default getdate(),
US_Contraseña varchar(50),
US_Nivel varchar (20))
GO*/
    public class Usuario
    {
        public int US_USCedula { get; set; }
        public String US_Nombre { get; set; }
        public String US_Apellido { get; set; }
        public String US_Ingreso { get; set; }
        public String US_Contrasena { get; set; }
        public String US_Nivel { get; set; }
        public int Control { get; set;}
        public String US_Usuario { get; set; }


    }

   



}



