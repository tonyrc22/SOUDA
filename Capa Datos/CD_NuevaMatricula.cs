using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Capa_Entidad;

namespace Capa_Datos
{
    public class CD_NuevaMatricula
    {
        public List<NuevaMatricula> Listar()
        {

            List<NuevaMatricula> lista = new List<NuevaMatricula>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    String query = "select C.CU_CodCurso,C.CU_FechaInicio,C.CU_Nombre,P.PR_Nombre+' '+p.PR_Apellido as PR_Nombre from Cursos C , Profe P where C.CU_CedProf = p.PR_CedProf";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                            new NuevaMatricula()
                            {
                                CU_CodCurso = Convert.ToInt32(dr["CU_CodCurso"]),
                                CU_FechaInicio = dr["CU_FechaInicio"].ToString().Remove(10),
                                CU_Nombre = dr["CU_Nombre"].ToString(),
                                PR_Nombre = dr["PR_Nombre"].ToString(),
                              
                                //select ES_CedulaES,ES_Nombre,ES_Apellido,ES_Telefono,ES_Correo,ES_Provincia,ES_FechaIngreso,ES_FechaNacim,ES_SEXO,ES_Discap,ES_PadreCed from estudiante

                            }
                            );


                        }

                    }


                }
            }
            catch
            {

                lista = new List<NuevaMatricula>();

            }


            return lista;
        }


        public int Registrar(MatriculaNueva obj, out string Mensaje)
        {

            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_RegistrarNuevaMatricula", oconexion);
                    cmd.Parameters.AddWithValue("ESCedula", obj.MA_CedulaES);
                    cmd.Parameters.AddWithValue("CodCurso", obj.MA_CodCurso);
                    cmd.Parameters.AddWithValue("USCedula", obj.MA_USCedula);
                    cmd.Parameters.AddWithValue("MA_SEDE", obj.MA_SEDE);
                    
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex)
            {

                idautogenerado = 0;
                Mensaje = ex.Message;
            }


            return idautogenerado;
        }









    }
}
