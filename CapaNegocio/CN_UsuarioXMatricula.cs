using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CapaNegocio
{
    public class CN_UsuarioXMatricula
    {
        private CD_UsuarioXMatricula objcapadatos = new CD_UsuarioXMatricula();

        public List<UsuarioXMatricula> Listar() 
        {

            return objcapadatos.Listar();



        }





    }
}
