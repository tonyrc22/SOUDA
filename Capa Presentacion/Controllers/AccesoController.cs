using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Entidad;
using CapaNegocio;
using static CapaNegocio.CN_Usuario;

namespace Capa_Presentacion.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CambiarClave()
        {
            return View();
        }

        public ActionResult Restablecer()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string usuariox,string clave )
        {

            Usuario oUsuario = new Usuario();
            oUsuario = new CN_Usuario().Listar().Where(u => u.US_Usuario == usuariox && u.US_Contrasena == clave).FirstOrDefault();
            

            if (oUsuario == null)
            {

                ViewBag.Error = "Usuario o Contrasena incorrecta";

                return View();


            }
            else {

               
                ViewBag.oUsuario = oUsuario.US_USCedula.ToString();
                
                ViewBag.Error = null;
                return RedirectToAction("Index","Home");

            }





         
        }










    }


}