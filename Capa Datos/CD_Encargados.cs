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
    public class CD_Encargados
    {

        public List<Encargado> Listar()
        {

            List<Encargado> lista = new List<Encargado>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    String query = "select PF_PFCedula,PF_Apellido,PF_telefono, PF_Nombre from Encargado order by PF_Nombre desc";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                            new Encargado()
                            {
                                PF_PFCedula = Convert.ToInt32(dr["PF_PFCedula"]),
                                PF_Nombre = dr["PF_Nombre"].ToString(),
                                PF_Apellido = dr["PF_Apellido"].ToString(),
                                PF_telefono = dr["PF_telefono"].ToString()
                                

                            }
                            );


                        }

                    }


                }
            }
            catch
            {

                lista = new List<Encargado>();

            }


            return lista;
        }

        public int Registrar(Encargado obj, out string Mensaje)
        {

            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_RegistrarEncargado", oconexion);
                    cmd.Parameters.AddWithValue("Cedula", obj.PF_PFCedula);
                    cmd.Parameters.AddWithValue("Nombre", obj.PF_Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.PF_Apellido);
                    cmd.Parameters.AddWithValue("Telefono", obj.PF_telefono);
                   
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

        public bool Editar(Encargado obj, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_EditarEncargado", oconexion);
                    cmd.Parameters.AddWithValue("Cedula", obj.PF_PFCedula);
                    cmd.Parameters.AddWithValue("Nombre", obj.PF_Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.PF_Apellido);
                    cmd.Parameters.AddWithValue("Telefono", obj.PF_telefono);
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
                    SqlCommand cmd = new SqlCommand("delete top (1) from Encargado where PF_PFCedula = @Cedula", oconexion);
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

