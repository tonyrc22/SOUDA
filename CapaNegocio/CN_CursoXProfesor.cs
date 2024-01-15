using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CapaNegocio
{
    public class CN_CursoXProfesor
    {
        private CD_CursoXProfesor objcapadatos = new CD_CursoXProfesor();

        public List<CursoXProfesor> Listar() //para traer toda la lista !!!!!
        {

            return objcapadatos.Listar();



        }





    }
}
