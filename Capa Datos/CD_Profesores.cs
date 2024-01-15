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
    public class CD_Profesores
    {

        public List<Profesor> Listar()
        {

            List<Profesor> lista = new List<Profesor>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    String query = "select PR_CedProf,PR_Nombre,PR_Apellido,PR_FechaIngreso,PR_Telefono from Profe";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                            new Profesor()
                            {
                                PR_CedProf = Convert.ToInt32(dr["PR_CedProf"]),
                                PR_Nombre = dr["PR_Nombre"].ToString(),
                                PR_Apellido = dr["PR_Apellido"].ToString(),
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

                lista = new List<Profesor>();

            }


            return lista;
        }

        public int Registrar(Profesor obj, out string Mensaje)
        {

            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_RegistrarProfesor", oconexion); // cambiar
                    cmd.Parameters.AddWithValue("Cedula", obj.PR_CedProf);
                    cmd.Parameters.AddWithValue("Nombre", obj.PR_Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.PR_Apellido);
                    cmd.Parameters.AddWithValue("FechaIngreso", obj.PR_FechaIngreso);
                    cmd.Parameters.AddWithValue("Telefono", obj.PR_Telefono);
                   
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

        public bool Editar(Profesor obj, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_EditarProfesor", oconexion);
                    cmd.Parameters.AddWithValue("Cedula", obj.PR_CedProf);
                    cmd.Parameters.AddWithValue("Nombre", obj.PR_Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.PR_Apellido);
                    cmd.Parameters.AddWithValue("FechaIngreso", obj.PR_FechaIngreso);
                    cmd.Parameters.AddWithValue("Telefono", obj.PR_Telefono);
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
                    SqlCommand cmd = new SqlCommand("delete top (1) from Profe where PR_CedProf = @Cedula", oconexion);
                    cmd.Parameters.AddWithValue("@Cedula", id);
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

