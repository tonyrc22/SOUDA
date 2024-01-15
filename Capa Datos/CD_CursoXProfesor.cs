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
    public class CD_CursoXProfesor
    {
        public List<CursoXProfesor> Listar()
        {

            List<CursoXProfesor> lista = new List<CursoXProfesor>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    String query = "select C.CU_CodCurso,C.CU_FechaInicio,C.CU_Nombre, P.PR_CedProf, (P.PR_Nombre+' '+P.PR_Apellido) as PR_Nombre,P.PR_FechaIngreso,P.PR_Telefono from Cursos C , Profe P Where (P.PR_CedProf=C.CU_CedProf) order by CU_FechaInicio Desc  ";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                            new CursoXProfesor()
                            {
                                CU_CodCurso = Convert.ToInt32(dr["CU_CodCurso"]),
                                CU_FechaInicio = dr["CU_FechaInicio"].ToString().Remove(10),
                                CU_Nombre = dr["CU_Nombre"].ToString(),
                                PR_Nombre = dr["PR_Nombre"].ToString(),
                                PR_CedProf = Convert.ToInt32(dr["PR_CedProf"]),
                                PR_FechaIngreso = dr["PR_FechaIngreso"].ToString().Remove(10),
                                PR_Telefono = dr["PR_Telefono"].ToString(),
                                

                            }
                            );


                        }

                    }


                }
            }
            catch
            {

                lista = new List<CursoXProfesor>();

            }


            return lista;
        }
    }
}
