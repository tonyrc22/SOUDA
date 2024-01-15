using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace CapaNegocio
{
    public class CN_estudiante
    {
        private CD_Estudiantes objcapadatos = new CD_Estudiantes();

        public List<estudiante> listar() //para traer toda la lista !!!!!
        { 
        
        return objcapadatos.Listar();

        
        
        }

        public int Registrar(estudiante obj, out string Mensaje) {

            Mensaje = string.Empty;  // Video 10 17min 

            if (string.IsNullOrEmpty(obj.ES_Nombre)  || string.IsNullOrWhiteSpace(obj.ES_Nombre)){
                Mensaje = "Nombre del estudiante no puede ser vacio";
                
            }
            else if (string.IsNullOrEmpty(obj.ES_Apellido) || string.IsNullOrWhiteSpace(obj.ES_Apellido))
            {
                Mensaje = "Apellido del estudiante no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_Telefono) || string.IsNullOrWhiteSpace(obj.ES_Telefono))
            {
                Mensaje = "Telefono del estudiante no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_Discap) || string.IsNullOrWhiteSpace(obj.ES_Discap))
            {
                Mensaje = "Discapacidad del estudiante no puede ser vacio";

            }
            else if ((obj.ES_CedulaES) == 0)
            {
                Mensaje = "Cedula del Estudiante no puede ser vacio";

            }
            else if ((obj.ES_PadreCed) == 0)
            {
                Mensaje = "Cedula del Encargado no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_Correo) || string.IsNullOrWhiteSpace(obj.ES_Correo))
            {
                Mensaje = "Correo del estudiante no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_Provincia) || string.IsNullOrWhiteSpace(obj.ES_Provincia))
            {
                Mensaje = "Provincia del estudiante no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_Telefono) || string.IsNullOrWhiteSpace(obj.ES_Telefono))
            {
                Mensaje = "Telefono del estudiante no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_FechaIngreso) || string.IsNullOrWhiteSpace(obj.ES_FechaIngreso))
            {
                Mensaje = "Fecha de Ingreso no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_FechaNacim) || string.IsNullOrWhiteSpace(obj.ES_FechaNacim))
            {
                Mensaje = "Fecha de Nacimiento no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_SEXO) || string.IsNullOrWhiteSpace(obj.ES_SEXO))
            {
                Mensaje = "Sexo del estudiante no puede ser vacio";

            }





            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = "test123";  // video 10 min 18 encriptar claves

                return objcapadatos.Registrar(obj, out Mensaje);

            }
            else { return 0; }



            
        }

        public bool Editar(estudiante obj, out string Mensaje)
        {

            Mensaje = string.Empty;  // Video 10 24min 

            if (string.IsNullOrEmpty(obj.ES_Nombre) || string.IsNullOrWhiteSpace(obj.ES_Nombre))
            {
                Mensaje = "Nombre del estudiante no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_Apellido) || string.IsNullOrWhiteSpace(obj.ES_Apellido))
            {
                Mensaje = "Apellido del estudiante no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_Telefono) || string.IsNullOrWhiteSpace(obj.ES_Telefono))
            {
                Mensaje = "Telefono del estudiante no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_Discap) || string.IsNullOrWhiteSpace(obj.ES_Discap))
            {
                Mensaje = "Discapacidad del estudiante no puede ser vacio";

            }
            else if ((obj.ES_CedulaES) == 0)
            {
                Mensaje = "Cedula del Estudiante no puede ser vacio";

            }
            else if ((obj.ES_PadreCed) == 0)
            {
                Mensaje = "Cedula del Encargado no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_Correo) || string.IsNullOrWhiteSpace(obj.ES_Correo))
            {
                Mensaje = "Correo del estudiante no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_Provincia) || string.IsNullOrWhiteSpace(obj.ES_Provincia))
            {
                Mensaje = "Provincia del estudiante no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_Telefono) || string.IsNullOrWhiteSpace(obj.ES_Telefono))
            {
                Mensaje = "Telefono del estudiante no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_FechaIngreso) || string.IsNullOrWhiteSpace(obj.ES_FechaIngreso))
            {
                Mensaje = "Fecha de Ingreso no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_FechaNacim) || string.IsNullOrWhiteSpace(obj.ES_FechaNacim))
            {
                Mensaje = "Fecha de Nacimiento no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.ES_SEXO) || string.IsNullOrWhiteSpace(obj.ES_SEXO))
            {
                Mensaje = "Sexo del estudiante no puede ser vacio";

            }






            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = "test123";  // video 10 min 18 encriptar claves

                return objcapadatos.Editar(obj, out Mensaje);

            }
            else {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objcapadatos.Eliminar(id, out Mensaje);

        }
            






    }
}
