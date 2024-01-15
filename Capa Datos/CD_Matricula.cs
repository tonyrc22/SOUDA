using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Matricula
    {
        public List<Matricula> Listar()
        {

            List<Matricula> lista = new List<Matricula>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    String query = " select M.MA_Transac,M.MA_SEDE,M.MA_CedulaES,M.MA_CodCurso,EN.PF_PFCedula,M.MA_USCedula,p.PR_CedProf as MA_CedProf ,E.ES_Nombre, C.CU_Nombre ,c.CU_FechaInicio, P.PR_Nombre, EN.PF_Nombre ,U.US_Nombre, M.MA_Fecha from Matricula M , Estudiante E ,Cursos C , Profe P ,Encargado EN ,Usuarios U where (E.ES_CedulaES = M.MA_CedulaES) and (M.MA_CodCurso= C.CU_CodCurso) and (p.PR_CedProf=C.CU_CedProf) and (EN.PF_PFCedula=E.ES_PadreCed)and (U.US_USCedula=m.MA_USCedula) order by MA_CedulaES desc";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                            new Matricula()
                            {
                                MA_Transac = Convert.ToInt32(dr["MA_Transac"]),
                                MA_SEDE = dr["MA_SEDE"].ToString(),
                                MA_CedulaES = Convert.ToInt32(dr["MA_CedulaES"]),
                                MA_CodCurso = Convert.ToInt32(dr["MA_CodCurso"]),
                                // MA_PFCedula = Convert.ToInt32(dr["MA_PFCedula"]),
                                MA_USCedula = Convert.ToInt32(dr["MA_USCedula"]),
                                MA_CedProf = Convert.ToInt32(dr["MA_CedProf"]),
                                ES_Nombre = dr["ES_Nombre"].ToString(),
                                CU_Nombre = dr["CU_Nombre"].ToString(),
                                PR_Nombre = dr["PR_Nombre"].ToString(),
                                PF_Nombre = dr["PF_Nombre"].ToString(),
                                US_Nombre = dr["US_Nombre"].ToString(),
                                MA_Fecha = dr["MA_Fecha"].ToString().Remove(10),
                                CU_FechaInicio = dr["CU_FechaInicio"].ToString().Remove(10)


                                //select ES_CedulaES,ES_Nombre,ES_Apellido,ES_Telefono,ES_Correo,ES_Provincia,ES_FechaIngreso,ES_FechaNacim,ES_SEXO,ES_Discap,ES_PadreCed from estudiante

                            }
                            ) ; 


                        }

                    }


                }
            }
            catch 
            {

                lista = new List<Matricula>();

            }


            return lista;
        }

        public int Registrar(Matricula obj, out string Mensaje)
        {

            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_RegistrarMatricula", oconexion);
                    cmd.Parameters.AddWithValue("Sede", obj.MA_SEDE);
                    cmd.Parameters.AddWithValue("CedulaES", obj.MA_CedulaES);
                    cmd.Parameters.AddWithValue("CodCurso", obj.MA_CodCurso);
                    cmd.Parameters.AddWithValue("PFCedula", obj.PF_PFCedula);
                    cmd.Parameters.AddWithValue("USCedula", obj.MA_USCedula);
                    cmd.Parameters.AddWithValue("CedProf", obj.MA_CedProf);
                  
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

        public bool Editar(Matricula obj, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_EditarMatricula", oconexion);
                    cmd.Parameters.AddWithValue("Sede", obj.MA_SEDE);
                    cmd.Parameters.AddWithValue("CedulaES", obj.MA_CedulaES);
                    cmd.Parameters.AddWithValue("CodCurso", obj.MA_CodCurso);
                    cmd.Parameters.AddWithValue("PFCedula", obj.PF_PFCedula);
                    cmd.Parameters.AddWithValue("USCedula", obj.MA_USCedula);
                    cmd.Parameters.AddWithValue("CedProf", obj.MA_CedProf);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }

            }
            catch (Exception ex)
            {

                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;

        }

        public bool Eliminar(int id, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top (1) from Matricula where MA_Transac = @Matricula", oconexion);
                    cmd.Parameters.AddWithValue("@Matricula", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;


                }



            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;








        }





    }


















}

