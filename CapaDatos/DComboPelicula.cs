using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
  public class DComboPelicula
    {
        private int id_pelicula;
        private string pelicula;

        public DComboPelicula(int id_pelicula, string pelicula)
        {
            this.id_pelicula = id_pelicula;
            this.pelicula = pelicula;
        }

        public DComboPelicula()
        {

        }
        public int Id_pelicula { get => id_pelicula; set => id_pelicula = value; }
        public string Pelicula { get => pelicula; set => pelicula = value; }

        public DataTable MostrarComboPelicula()
        {
            DataTable DtResultado = new DataTable("Peliculas");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "combo_Pelicula";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    }
}
