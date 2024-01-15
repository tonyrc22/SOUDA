using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Entidad;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace Capa_Datos // Vid05 min17
{
    public class CD_Estudiantes
    {
        public List<estudiante> Listar() {

            List<estudiante> lista = new List<estudiante>();

            try {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn)) {

                    String query = "select ES_CedulaES,ES_Nombre,ES_Apellido,ES_Telefono,ES_Correo,ES_Provincia,ES_FechaIngreso,ES_FechaNacim,ES_SEXO,ES_Discap,ES_PadreCed from estudiante order by ES_FechaIngreso desc";
                    SqlCommand cmd = new SqlCommand (query,oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read())
                        {
                            lista.Add(
                            new estudiante()
                            {
                                ES_CedulaES = Convert.ToInt32(dr["ES_CedulaES"]),
                                ES_Nombre = dr["ES_Nombre"].ToString(),
                                ES_Apellido = dr["ES_Apellido"].ToString(),
                                ES_Telefono = dr["ES_Telefono"].ToString(),
                                ES_Correo = dr["ES_Correo"].ToString(),
                                ES_Provincia = dr["ES_Provincia"].ToString(),
                                ES_FechaIngreso = dr["ES_FechaIngreso"].ToString().Remove(10),
                                ES_FechaNacim = dr["ES_FechaNacim"].ToString().Remove(10),
                                ES_SEXO = dr["ES_SEXO"].ToString(),
                                ES_Discap = dr["ES_Discap"].ToString(),
                                ES_PadreCed = Convert.ToInt32(dr["ES_PadreCed"])
                                //select ES_CedulaES,ES_Nombre,ES_Apellido,ES_Telefono,ES_Correo,ES_Provincia,ES_FechaIngreso,ES_FechaNacim,ES_SEXO,ES_Discap,ES_PadreCed from estudiante

                            }
                            );


                        }

                    }


                }
            }
            catch { 
            
                lista= new List<estudiante> ();
            
            }


         return lista;
        }

        public int Registrar(estudiante obj, out string Mensaje) {

            int idautogenerado = 0;

            Mensaje = string.Empty;
            try {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn)) { 
                
                    SqlCommand cmd = new SqlCommand ("SP_RegistrarEstudiante", oconexion);
                    cmd.Parameters.AddWithValue("CedulaES", obj.ES_CedulaES);
                    cmd.Parameters.AddWithValue("Nombre", obj.ES_Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.ES_Apellido);
                    cmd.Parameters.AddWithValue("Telefono", obj.ES_Telefono);
                    cmd.Parameters.AddWithValue("Correo", obj.ES_Correo);
                    cmd.Parameters.AddWithValue("Provincia", obj.ES_Provincia);
                    cmd.Parameters.AddWithValue("FechaIngreso", obj.ES_FechaIngreso);
                    cmd.Parameters.AddWithValue("FechaNacim", obj.ES_FechaNacim);
                    cmd.Parameters.AddWithValue("SEXO", obj.ES_SEXO);
                    cmd.Parameters.AddWithValue("Discap", obj.ES_Discap);
                    cmd.Parameters.AddWithValue("PadreCed", obj.ES_PadreCed);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();               

                }
            
            }
            catch (Exception ex) {

                idautogenerado = 0;
                Mensaje = ex.Message;                   
            }
        
        
        return idautogenerado;
        }

        public bool Editar(estudiante obj, out string Mensaje) {

            bool resultado = false;
            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_EditarEstudiante", oconexion);
                    cmd.Parameters.AddWithValue("CedulaES", obj.ES_CedulaES);
                    cmd.Parameters.AddWithValue("Nombre", obj.ES_Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.ES_Apellido);
                    cmd.Parameters.AddWithValue("Telefono", obj.ES_Telefono);
                    cmd.Parameters.AddWithValue("Correo", obj.ES_Correo);
                    cmd.Parameters.AddWithValue("Provincia", obj.ES_Provincia);
                    cmd.Parameters.AddWithValue("FechaIngreso", obj.ES_FechaIngreso);
                    cmd.Parameters.AddWithValue("FechaNacim", obj.ES_FechaNacim);
                    cmd.Parameters.AddWithValue("SEXO", obj.ES_SEXO);
                    cmd.Parameters.AddWithValue("Discap", obj.ES_Discap);
                    cmd.Parameters.AddWithValue("PadreCed", obj.ES_PadreCed);
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

        public bool Eliminar(int id, out string Mensaje) { 

            bool resultado = false;
            Mensaje = string.Empty;
            try {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn)) {
                    SqlCommand cmd = new SqlCommand("delete  from Matricula where (MA_CedulaES = @CedulaES); delete from Estudiante where (ES_CedulaES = @CedulaES);", oconexion);
                    cmd.Parameters.AddWithValue("@CedulaES", id);
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
