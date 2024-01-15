using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Entidad;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace Capa_Datos
{
    public class CD_UsuarioXMatricula
    {
        public List<UsuarioXMatricula> Listar()
        {

            List<UsuarioXMatricula> lista = new List<UsuarioXMatricula>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    String query = "select M.MA_Transac,M.MA_SEDE,M.MA_Fecha,M.MA_CedulaES,(E.ES_Nombre+' '+ E.ES_Apellido) as ES_Nombre ,M.MA_CodCurso,C.CU_Nombre,M.MA_USCedula,(U.US_Nombre+' '+U.US_Apellido) as US_Nombre ,U.US_Usuario  from Estudiante E, Cursos C , Matricula M ,Usuarios U where (C.CU_CodCurso=M.MA_CodCurso) and (E.ES_CedulaES=M.MA_CedulaES) and (U.US_USCedula=M.MA_USCedula)";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                            new UsuarioXMatricula()
                            {
                                MA_Transac = Convert.ToInt32(dr["MA_Transac"]),
                                MA_SEDE = dr["MA_SEDE"].ToString(),
                                MA_CedulaES = Convert.ToInt32(dr["MA_CedulaES"]),
                                MA_CodCurso = Convert.ToInt32(dr["MA_CodCurso"]),
                                CU_Nombre = dr["CU_Nombre"].ToString(),
                                MA_USCedula = Convert.ToInt32(dr["MA_USCedula"]),
                                MA_Fecha = dr["MA_Fecha"].ToString().Remove(10),
                                US_Nombre = dr["US_Nombre"].ToString(),
                                US_Usuario = dr["US_Usuario"].ToString(),
                                ES_Nombre = dr["ES_Nombre"].ToString(),


                            }
                            );


                        }

                    }


                }
            }
            catch
            {

                lista = new List<UsuarioXMatricula>();

            }


            return lista;
        }
    }
}
