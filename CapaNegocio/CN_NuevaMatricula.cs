using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_NuevaMatricula
    {
        private CD_NuevaMatricula objcapadatos = new CD_NuevaMatricula();

        public List<NuevaMatricula> Listar() //para traer toda la lista !!!!!
        {

            return objcapadatos.Listar();

        }


        public int Registrar(MatriculaNueva obj, out string Mensaje)
        {

            Mensaje = string.Empty;  // Video 10 17min 

            if (string.IsNullOrEmpty(obj.MA_SEDE) || string.IsNullOrWhiteSpace(obj.MA_SEDE))
            {
                Mensaje = "La Sede no puede ser vacio";

            }
            else if ((obj.MA_CedulaES) == 0)
            {
                Mensaje = "El estudiante no puede ser vacio";

            }
            else if ((obj.MA_CodCurso) == 0)
            {
                Mensaje = "Curso no puede ser vacio";

            }
            else if ((obj.MA_USCedula) == 0)
            {
                Mensaje = " Usuario no puede ser vacio";

            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = "test123";  // video 10 min 18 encriptar claves

                return objcapadatos.Registrar(obj, out Mensaje);

            }
            else { return 0; }




        }




    }
}
