using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Curso
    {
        private CD_Cursos objcapadatos = new CD_Cursos();

        public List<Cursos> Listar() //para traer toda la lista !!!!!
        {

            return objcapadatos.Listar();



        }

        public int Registrar(Cursos obj, out string Mensaje)
        {

            Mensaje = string.Empty;  // Video 10 17min 

            if (string.IsNullOrEmpty(obj.CU_Nombre) || string.IsNullOrWhiteSpace(obj.CU_Nombre))
            {
                Mensaje = "Nombre del Curso no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.CU_FechaInicio) || string.IsNullOrWhiteSpace(obj.CU_FechaInicio))
            {
                Mensaje = " La Fecha de Inicio del curso no puede ser vacio";

            }
            else if ((obj.CU_CodCurso) == 0) 
            {
                Mensaje = "El codigo del Curso no puede ser Vacio";

            }
            else if ((obj.CU_CedProf) == 0)
            {
                Mensaje = " Seleccione un Profesor ";

            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = "test123";  // video 10 min 18 encriptar claves

                return objcapadatos.Registrar(obj, out Mensaje);

            }
            else { return 0; }




        }

        public bool Editar(Cursos obj, out string Mensaje)
        {

            Mensaje = string.Empty;  // Video 10 24min 

            if (string.IsNullOrEmpty(obj.CU_Nombre) || string.IsNullOrWhiteSpace(obj.CU_Nombre))
            {
                Mensaje = "Nombre del Curso no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.CU_FechaInicio) || string.IsNullOrWhiteSpace(obj.CU_FechaInicio))
            {
                Mensaje = " La Fecha de Inicio del curso no puede ser vacio";

            }
            else if ((obj.CU_CodCurso) == 0)
            {
                Mensaje = "El codigo del Curso no puede ser Vacio";

            }
            else if ((obj.CU_CedProf) == 0)
            {
                Mensaje = " Seleccione un Profesor ";

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

