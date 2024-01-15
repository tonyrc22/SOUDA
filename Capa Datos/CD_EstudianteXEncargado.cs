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
    public class CD_EstudianteXEncargado
    {
        public List<EstudianteXEncargado> Listar()
        {

            List<EstudianteXEncargado> lista = new List<EstudianteXEncargado>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    String query = "select E.ES_CedulaES,(E.ES_Nombre+' '+E.ES_Apellido) as ES_Nombre ,E.ES_Telefono,EN.PF_PFCedula, (EN.PF_Nombre+' '+EN.PF_Apellido) as PF_Nombre,EN.PF_telefono  from estudiante E, Encargado EN where (EN.PF_PFCedula=E.ES_PadreCed)";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                            new EstudianteXEncargado()
                            {
                                ES_CedulaES = Convert.ToInt32(dr["ES_CedulaES"]),
                                ES_Nombre = dr["ES_Nombre"].ToString(),
                                //ES_Apellido = dr["ES_Apellido"].ToString(),
                                ES_Telefono = dr["ES_Telefono"].ToString(),
                                PF_PFCedula = Convert.ToInt32(dr["PF_PFCedula"]),
                                //PF_Apellido = dr["PF_Apellido"].ToString(),
                                PF_telefono = dr["PF_telefono"].ToString(),
                                PF_Nombre = dr["PF_Nombre"].ToString(),
                                

                            }
                            );


                        }

                    }


                }
            }
            catch
            {

                lista = new List<EstudianteXEncargado>();

            }


            return lista;
        }
    }
}
