using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Profesor
    {

        private CD_Profesores objcapadatos = new CD_Profesores();

        public List<Profesor> Listar() //para traer toda la lista !!!!!
        {

            return objcapadatos.Listar();



        }

        public int Registrar(Profesor obj, out string Mensaje)
        {

            Mensaje = string.Empty;  // Video 10 17min 

            if (string.IsNullOrEmpty(obj.PR_Nombre) || string.IsNullOrWhiteSpace(obj.PR_Nombre))
            {
                Mensaje = "Nombre del Profesor no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.PR_Apellido) || string.IsNullOrWhiteSpace(obj.PR_Apellido))
            {
                Mensaje = "Apellido del Profesor no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.PR_FechaIngreso) || string.IsNullOrWhiteSpace(obj.PR_FechaIngreso))
            {
                Mensaje = "Fecha de Ingreso no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.PR_Telefono) || string.IsNullOrWhiteSpace(obj.PR_Telefono))
            {
                Mensaje = "Numero de telefono no puede ser vacio";

            }
            else if ((obj.PR_CedProf) == 0)
            {
                Mensaje = " Numero de Cedula invalido ";

            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = "test123";  // video 10 min 18 encriptar claves

                return objcapadatos.Registrar(obj, out Mensaje);

            }
            else { return 0; }




        }

        public bool Editar(Profesor obj, out string Mensaje)
        {

            Mensaje = string.Empty;  // Video 10 24min 

            if (string.IsNullOrEmpty(obj.PR_Nombre) || string.IsNullOrWhiteSpace(obj.PR_Nombre))
            {
                Mensaje = "Nombre del Profesor no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.PR_Apellido) || string.IsNullOrWhiteSpace(obj.PR_Apellido))
            {
                Mensaje = "Apellido del Profesor no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.PR_FechaIngreso) || string.IsNullOrWhiteSpace(obj.PR_FechaIngreso))
            {
                Mensaje = "Fecha de Ingreso no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.PR_Telefono) || string.IsNullOrWhiteSpace(obj.PR_Telefono))
            {
                Mensaje = "Numero de telefono no puede ser vacio";

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

