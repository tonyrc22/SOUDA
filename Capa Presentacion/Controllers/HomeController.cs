using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Capa_Entidad;
using CapaNegocio;
using Microsoft.Ajax.Utilities;
using static CapaNegocio.CN_Usuario;

namespace Capa_Presentacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Estudiantes()
        {
            return View();
        }

        public ActionResult Padres()
        {
            return View();
        }

        public ActionResult Profesores()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }

        public ActionResult Matricula()
        {
            return View();
        }

        public ActionResult Cursos()
        {
            return View();
        }

        public ActionResult NuevaMatricula()
        {
            return View();  
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult EstudiantesXEncargado()
        {
            return View();
        }

        public ActionResult CursoXProfesor()
        {
            return View();
        }

        public ActionResult UsuarioXMatricula() { 
            return View();
        
        }






        // ESTUDIANTES ////////////////////////////////
        [HttpGet]
        public JsonResult Listarestudiante() {

            //select ES_CedulaES,ES_Nombre,ES_Apellido,ES_Telefono,ES_Correo,ES_Provincia,ES_FechaIngreso,ES_FechaNacim,ES_SEXO,ES_Discap,ES_PadreCed from estudiante
            List<estudiante> olista = new List<estudiante>();
            olista = new CN_estudiante().listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }



        [HttpPost] // Vid 11 Inicio
        public JsonResult Guardarestudiante(estudiante objeto) {
            

            object resultado;
            string mensaje = string.Empty;

            if (objeto.control == 0)
            {

                resultado = new CN_estudiante().Registrar(objeto, out mensaje);
            }
            else {

                resultado = new CN_estudiante().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado , mensaje = mensaje}, JsonRequestBehavior.AllowGet);

        }

        [HttpPost] // Vid 13 min 5
        public JsonResult Eliminarestudiante(int id) {
        
        bool respuesta = false;
        string mensaje = string.Empty;
        respuesta = new CN_estudiante().Eliminar(id, out mensaje);



            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        //Profesores /////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public JsonResult Listarprofesor()
        {

            //select ES_CedulaES,ES_Nombre,ES_Apellido,ES_Telefono,ES_Correo,ES_Provincia,ES_FechaIngreso,ES_FechaNacim,ES_SEXO,ES_Discap,ES_PadreCed from estudiante
            List<Profesor> olista = new List<Profesor>();
            olista = new CN_Profesor().Listar();

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }



        [HttpPost] // Vid 11 Inicio
        public JsonResult Guardarprofesor(Profesor objeto)
        {


            object resultado;
            string mensaje = string.Empty;

            if (objeto.Control == 0)
            {

                resultado = new CN_Profesor().Registrar(objeto, out mensaje);
            }
            else
            {

                resultado = new CN_Profesor().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost] // Vid 13 min 5
        public JsonResult Eliminarprofesor(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Profesor().Eliminar(id, out mensaje);



            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }


        ///////////////////////////ENCARGADOS//////////////////////////////////////////////////

        [HttpGet]
        public JsonResult Listarencargado()
        {

            
            List<Encargado> olista = new List<Encargado>();
            olista = new CN_Encargado().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }



        [HttpPost] // Vid 11 Inicio
        public JsonResult Guardarencargado(Encargado objeto)
        {


            object resultado;
            string mensaje = string.Empty;

            if (objeto.Control == 0)
            {

                resultado = new CN_Encargado().Registrar(objeto, out mensaje);
            }
            else
            {

                resultado = new CN_Encargado().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost] // Vid 13 min 5
        public JsonResult Eliminarencargado(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Encargado().Eliminar(id, out mensaje);



            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        ///////////////////////////////////Usuarios//////////////////////////////////////////
        ///
        [HttpGet]
        public JsonResult Listarusuario()
        {

           
            List<Usuario> olista = new List<Usuario>();
            olista = new CN_Usuario().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }



        [HttpPost] // Vid 11 Inicio
        public JsonResult Guardarusuario(Usuario objeto)
        {


            object resultado;
            string mensaje = string.Empty;

            if (objeto.Control == 0)
            {

                resultado = new CN_Usuario().Registrar(objeto, out mensaje);
            }
            else
            {

                resultado = new CN_Usuario().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost] // Vid 13 min 5
        public JsonResult Eliminarusuario(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Usuario().Eliminar(id, out mensaje);



            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }


        ///////////////////////////////////Cursos//////////////////////////////////////////
        ///
        [HttpGet]
        public JsonResult Listarcurso()
        {


            List<Cursos> olista = new List<Cursos>();
            olista = new CN_Curso().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }



        [HttpPost] // Vid 11 Inicio
        public JsonResult Guardarcurso(Cursos objeto)
        {


            object resultado;
            string mensaje = string.Empty;

            if (objeto.Control == 0)
            {

                resultado = new CN_Curso().Registrar(objeto, out mensaje);
            }
            else
            {

                resultado = new CN_Curso().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost] // Vid 13 min 5
        public JsonResult Eliminarcurso(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Curso().Eliminar(id, out mensaje);



            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }



        /////////////////////////////////////////////Matricula///////////////////////////////////////////////////////////

        [HttpGet]
        public JsonResult Listarmatricula()
        {

            //select ES_CedulaES,ES_Nombre,ES_Apellido,ES_Telefono,ES_Correo,ES_Provincia,ES_FechaIngreso,ES_FechaNacim,ES_SEXO,ES_Discap,ES_PadreCed from estudiante
            List<Matricula> olista = new List<Matricula>();
            olista = new CN_Matricula().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }



        [HttpPost] // Vid 11 Inicio
        public JsonResult Guardarmatricula(Matricula objeto)
        {


            object resultado;
            string mensaje = string.Empty;

            if (objeto.Control == 0)
            {

                resultado = new CN_Matricula().Registrar(objeto, out mensaje);
            }
            else
            {

                resultado = new CN_Matricula().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost] // Vid 13 min 5
        public JsonResult Eliminarmatricula(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Matricula().Eliminar(id, out mensaje);



            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }




        //////////////////////////////////////////////////////////NuevaMatricula ////////////////////////////////////////////
        ///

        [HttpGet]
        public JsonResult Listarnuevamatricula()
        {

            //select ES_CedulaES,ES_Nombre,ES_Apellido,ES_Telefono,ES_Correo,ES_Provincia,ES_FechaIngreso,ES_FechaNacim,ES_SEXO,ES_Discap,ES_PadreCed from estudiante
            List<NuevaMatricula> olista = new List<NuevaMatricula>();
            olista = new CN_NuevaMatricula().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost] // Vid 11 Inicio
        public JsonResult GuardarMatriculaNueva(MatriculaNueva objeto)
        {


            object resultado;
            string mensaje = string.Empty;

            if (objeto.Control == 0)
            {

                resultado = new CN_NuevaMatricula().Registrar(objeto, out mensaje);
            }
            else
            {
                

               resultado = new CN_NuevaMatricula().Registrar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }


        // ESTUDIANTESXENCARGADO ////////////////////////////////
        [HttpGet]
        public JsonResult Listarestudiantexencargado()
        {

            
            List<EstudianteXEncargado> olista = new List<EstudianteXEncargado>();
            olista = new CN_EstudianteXEncargado().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }

        // CursoXProfesor ////////////////////////////////
        [HttpGet]
        public JsonResult Listarcursoxprofesor()
        {

            
            List<CursoXProfesor> olista = new List<CursoXProfesor>();
            olista = new CN_CursoXProfesor().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }
        ///////////////////////////////////////////////////////////
        [HttpPost]
        public ActionResult Indexo(string usuariox, string clave)
        {

            Usuario oUsuario = new Usuario();
            oUsuario = new CN_Usuario().Listar().Where(u => u.US_Usuario == usuariox && u.US_Contrasena == clave).FirstOrDefault();


            if (oUsuario == null)
            {

                ViewBag.Error = "Usuario o Contrasena incorrecta";
                

                return View();
                 

            }
            else
            {

                var Nombre = "";
                ViewBag.Cedula = oUsuario.US_USCedula.ToString();
                
                
                Nombre = oUsuario.US_Nombre.ToString() + " " + oUsuario.US_Apellido.ToString();

                ViewBag.Nombre = Nombre;
                ViewBag.Ape = oUsuario.US_Apellido.ToString();


                ViewData["mensaje"] = "hola";
                

                ViewBag.Error = null;
                return View();
                 //return RedirectToAction("Index", "Home");



            }






        }




        public ActionResult Indexo()
        {
            return View();
        }


        public JsonResult Listarusuarioxmatricula()
        {


            List<UsuarioXMatricula> olista = new List<UsuarioXMatricula>();
            olista = new CN_UsuarioXMatricula().Listar();


            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }


















    }
}