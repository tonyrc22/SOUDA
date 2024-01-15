using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuarios objcapadatos = new CD_Usuarios();

        public List<Usuario> Listar() //para traer toda la lista !!!!!
        {

            return objcapadatos.Listar();

        }

        public int Registrar(Usuario obj, out string Mensaje)
        {

            Mensaje = string.Empty;  // Video 10 17min 

            if (string.IsNullOrEmpty(obj.US_Nombre) || string.IsNullOrWhiteSpace(obj.US_Nombre))
            {
                Mensaje = "Nombre del Usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.US_Apellido) || string.IsNullOrWhiteSpace(obj.US_Apellido))
            {
                Mensaje = "Apellido del Usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.US_Ingreso) || string.IsNullOrWhiteSpace(obj.US_Ingreso))
            {
                Mensaje = "Fecha de Ingreso del Usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.US_Contrasena) || string.IsNullOrWhiteSpace(obj.US_Contrasena))
            {
                Mensaje = "Contrasena del Usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.US_Nivel) || string.IsNullOrWhiteSpace(obj.US_Nivel))
            {
                Mensaje = "Nivel del Usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.US_Usuario) || string.IsNullOrWhiteSpace(obj.US_Usuario))
            {
                Mensaje = "Usuario Unico no puede ser vacio";

            }
            else if ((obj.US_USCedula) == 0)
            {
                Mensaje = "La cedula del Usuario no puede ser vacio";

            }



            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = "test123";  // video 10 min 18 encriptar claves

                return objcapadatos.Registrar(obj, out Mensaje);

            }
            else { return 0; }




        }

        public bool Editar(Usuario obj, out string Mensaje)
        {

            Mensaje = string.Empty;  // Video 10 24min 

            if (string.IsNullOrEmpty(obj.US_Nombre) || string.IsNullOrWhiteSpace(obj.US_Nombre))
            {
                Mensaje = "Nombre del Usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.US_Apellido) || string.IsNullOrWhiteSpace(obj.US_Apellido))
            {
                Mensaje = "Apellido del Usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.US_Ingreso) || string.IsNullOrWhiteSpace(obj.US_Ingreso))
            {
                Mensaje = "Fecha de Ingreso del Usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.US_Contrasena) || string.IsNullOrWhiteSpace(obj.US_Contrasena))
            {
                Mensaje = "Contrasena del Usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.US_Nivel) || string.IsNullOrWhiteSpace(obj.US_Nivel))
            {
                Mensaje = "Nivel del Usuario no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.US_Usuario) || string.IsNullOrWhiteSpace(obj.US_Usuario))
            {
                Mensaje = "Usuario Unico no puede ser vacio";

            }
            else if ((obj.US_USCedula) == 0)
            {
                Mensaje = "La cedula del Usuario no puede ser vacio";

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



        public static class Funciones
        {
            public static string valorGlobal = "";
        }








    }
}
