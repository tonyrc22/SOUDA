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
    public class CD_Cursos
    {
        public List<Cursos> Listar()
        {

            List<Cursos> lista = new List<Cursos>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    String query = "Select CU_CodCurso, CU_FechaInicio , CU_Nombre from Cursos order by CU_FechaInicio Desc ";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                            new Cursos()
                            {
                                CU_CodCurso = Convert.ToInt32(dr["CU_CodCurso"]),
                                CU_FechaInicio = dr["CU_FechaInicio"].ToString().Remove(10),
                                CU_Nombre = dr["CU_Nombre"].ToString(),
                                
                            }
                            );


                        }

                    }


                }
            }
            catch
            {

                lista = new List<Cursos>();

            }


            return lista;
        }

        public int Registrar(Cursos obj, out string Mensaje)
        {

            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_RegistrarCurso", oconexion);
                    cmd.Parameters.AddWithValue("Codigo", Convert.ToInt32(obj.CU_CodCurso));
                    cmd.Parameters.AddWithValue("Nombre", obj.CU_Nombre);
                    cmd.Parameters.AddWithValue("FechaIni", obj.CU_FechaInicio);
                    cmd.Parameters.AddWithValue("CedulaProf", Convert.ToInt32(obj.CU_CedProf));

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

        public bool Editar(Cursos obj, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_EditarCurso", oconexion);
                    cmd.Parameters.AddWithValue("Codigo", obj.CU_CodCurso);
                    cmd.Parameters.AddWithValue("Nombre", obj.CU_Nombre);
                    cmd.Parameters.AddWithValue("FechaIni", obj.CU_FechaInicio);
                    cmd.Parameters.AddWithValue("CedulaProf", obj.CU_CedProf);
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
                    SqlCommand cmd = new SqlCommand("delete top (1) from Cursos where CU_CodCurso = @Codigo", oconexion);
                    cmd.Parameters.AddWithValue("@Codigo", id);
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

