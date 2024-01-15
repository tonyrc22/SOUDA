using Capa_Datos;
using Capa_Datos.DB_SOUDADataSetTableAdapters;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Encargado
    {
        private CD_Encargados objcapadatos = new CD_Encargados();

        public List<Encargado> Listar() //para traer toda la lista !!!!!
        {

            return objcapadatos.Listar();



        }

        public int Registrar(Encargado obj, out string Mensaje)
        {

            Mensaje = string.Empty;  // Video 10 17min 

            if (string.IsNullOrEmpty(obj.PF_Nombre) || string.IsNullOrWhiteSpace(obj.PF_Nombre))
            {
                Mensaje = "Nombre del Encargado no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.PF_Apellido) || string.IsNullOrWhiteSpace(obj.PF_Apellido))
            {
                Mensaje = "Apellido del Encargado no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.PF_telefono) || string.IsNullOrWhiteSpace(obj.PF_telefono))
            {
                Mensaje = "Telefono del Encargado no puede ser vacio";

            }
            else if ((obj.PF_PFCedula) == 0 )
            {
                Mensaje = "Cedula del Encargado no puede ser vacio";

            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = "test123";  // video 10 min 18 encriptar claves

                return objcapadatos.Registrar(obj, out Mensaje);

            }
            else { return 0; }




        }

        public bool Editar(Encargado obj, out string Mensaje)
        {

            Mensaje = string.Empty;  // Video 10 24min 

            if (string.IsNullOrEmpty(obj.PF_Nombre) || string.IsNullOrWhiteSpace(obj.PF_Nombre))
            {
                Mensaje = "Nombre del Encargado no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.PF_Apellido) || string.IsNullOrWhiteSpace(obj.PF_Apellido))
            {
                Mensaje = "Apellido del Encargado no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.PF_telefono) || string.IsNullOrWhiteSpace(obj.PF_telefono))
            {
                Mensaje = "Telefono del Encargado no puede ser vacio";

            }
            else if ((obj.PF_PFCedula) == 0)
            {
                Mensaje = "Cedula del Encargado no puede ser vacio";

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
