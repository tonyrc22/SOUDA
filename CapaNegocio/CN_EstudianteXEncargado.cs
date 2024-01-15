using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CapaNegocio
{
    public class CN_EstudianteXEncargado
    {
        private CD_EstudianteXEncargado objcapadatos = new CD_EstudianteXEncargado();

        public List<EstudianteXEncargado> Listar() //para traer toda la lista !!!!!
        {

            return objcapadatos.Listar();



        }





    }
}
