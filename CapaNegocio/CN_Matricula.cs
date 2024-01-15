using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Matricula
    {
        private CD_Matricula objcapadatos = new CD_Matricula();

        public List<Matricula> Listar() //para traer toda la lista !!!!!
        {

            return objcapadatos.Listar();



        }

        public int Registrar(Matricula obj, out string Mensaje)
        {

            Mensaje = string.Empty;  // Video 10 17min 

            if (string.IsNullOrEmpty(obj.MA_SEDE) || string.IsNullOrWhiteSpace(obj.MA_SEDE))
            {
                Mensaje = "Sede de Matricula no puede ser vacio";

            }
            else if ((obj.MA_CedulaES) == 0)
            {
                Mensaje = "Cedula del estudiante no puede ser vacio";

            }
            else if ((obj.MA_CodCurso) == 0)
            {
                Mensaje = "Curso no puede ser vacio";

            }
            else if ((obj.PF_PFCedula) == 0)
            {
                Mensaje = "Padre del estudiante no puede ser vacio";

            }
            else if ((obj.MA_USCedula) == 0)
            {
                Mensaje = "Usuario no puede ser vacio";

            }
            else if ((obj.MA_CedProf) == 0)
            {
                Mensaje = "Prof no puede ser vacio";

            }



            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = "test123";  // video 10 min 18 encriptar claves

                return objcapadatos.Registrar(obj, out Mensaje);

            }
            else { return 0; }




        }

        public bool Editar(Matricula obj, out string Mensaje)
        {

            Mensaje = string.Empty;  // Video 10 24min 

            if (string.IsNullOrEmpty(obj.MA_SEDE) || string.IsNullOrWhiteSpace(obj.MA_SEDE))
            {
                Mensaje = "Sede de Matricula no puede ser vacio";

            }
            else if ((obj.MA_CedulaES) == 0)
            {
                Mensaje = "Cedula del estudiante no puede ser vacio";

            }
            else if ((obj.MA_CodCurso) == 0)
            {
                Mensaje = "Curso no puede ser vacio";

            }
            else if ((obj.PF_PFCedula) == 0)
            {
                Mensaje = "Padre del estudiante no puede ser vacio";

            }
            else if ((obj.MA_USCedula) == 0)
            {
                Mensaje = "Usuario no puede ser vacio";

            }
            else if ((obj.MA_CedProf) == 0)
            {
                Mensaje = "Prof no puede ser vacio";

            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = "test123";  // video 10 min 18 encriptar claves

                return objcapadatos.Editar(obj, out Mensaje);

            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objcapadatos.Eliminar(id, out Mensaje);

        }







    }







}

