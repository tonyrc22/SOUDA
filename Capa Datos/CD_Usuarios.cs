using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.SqlServer.Server;

namespace Capa_Datos
{

    public class CD_Usuarios
    {
        public List<Usuario> Listar()
        {
            var Fechas = "";
            

            List<Usuario> lista = new List<Usuario>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    String query = "Select US_USCedula,US_Nombre,US_Apellido,US_Ingreso,US_Contrasena,US_Nivel,US_Usuario from Usuarios";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                            new Usuario()
                            {
                                US_USCedula = Convert.ToInt32(dr["US_USCedula"]),
                                US_Nombre = dr["US_Nombre"].ToString(),
                               US_Ingreso =  dr["US_Ingreso"].ToString().Remove(10),
                                US_Apellido = dr["US_Apellido"].ToString(),
                               // US_Ingreso = dr["US_Ingreso"].ToString(),
                                US_Contrasena = dr["US_Contrasena"].ToString(),
                                US_Nivel = dr["US_Nivel"].ToString(),
                                US_Usuario = dr["US_Usuario"].ToString()
                                

                            }
                            );


                        }

                    }


                }
            }
            catch
            {

                lista = new List<Usuario>();

            }


            return lista;
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {

            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_RegistrarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Cedula", obj.US_USCedula);
                    cmd.Parameters.AddWithValue("Nombre", obj.US_Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.US_Apellido);
                    cmd.Parameters.AddWithValue("Ingreso", obj.US_Ingreso);
                    cmd.Parameters.AddWithValue("Contrasena", obj.US_Contrasena);
                    cmd.Parameters.AddWithValue("Nivel", obj.US_Nivel);
                    cmd.Parameters.AddWithValue("Usuario", obj.US_Usuario);
                   
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

        public bool Editar(Usuario obj, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_EditarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Cedula", obj.US_USCedula);
                    cmd.Parameters.AddWithValue("Nombre", obj.US_Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.US_Apellido);
                    cmd.Parameters.AddWithValue("Ingreso", obj.US_Ingreso);
                    cmd.Parameters.AddWithValue("Contrasena", obj.US_Contrasena);
                    cmd.Parameters.AddWithValue("Nivel", obj.US_Nivel);
                    cmd.Parameters.AddWithValue("Usuario", obj.US_Usuario);

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
                    SqlCommand cmd = new SqlCommand("delete top (1) from Usuarios where US_USCedula = @Cedula", oconexion);
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


        //public bool Cambiarclave(int idusuario,String NuevaClave, out string Mensaje)
        //{

        //    bool resultado = false;
        //    Mensaje = string.Empty;
        //    try
        //    {
        //        using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
        //        {
        //            SqlCommand cmd = new SqlCommand("update Usuarios set clave where US_USCedula = @Cedula", oconexion);
        //            cmd.Parameters.AddWithValue("@Cedula", id);
        //            cmd.CommandType = CommandType.Text;
        //            oconexion.Open();
        //            resultado = cmd.ExecuteNonQuery() > 0 ? true : false;


        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        resultado = false;
        //        Mensaje = ex.Message;
        //    }
        //    return resultado;


        //}



        public bool BuscarUSU(Usuario obj, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_EditarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Cedula", obj.US_USCedula);
                    cmd.Parameters.AddWithValue("Nombre", obj.US_Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.US_Apellido);
                    cmd.Parameters.AddWithValue("Ingreso", obj.US_Ingreso);
                    cmd.Parameters.AddWithValue("Contrasena", obj.US_Contrasena);
                    cmd.Parameters.AddWithValue("Nivel", obj.US_Nivel);
                    cmd.Parameters.AddWithValue("Usuario", obj.US_Usuario);

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







    }






}
