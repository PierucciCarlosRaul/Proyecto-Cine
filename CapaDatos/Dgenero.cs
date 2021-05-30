using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Dgenero
    {
        private int id_genero;
        private string genero;

        public Dgenero(int id_genero, string genero)
        {
            this.id_genero = id_genero;
            this.genero = genero;
        }

        public Dgenero()
        {

        }
        public int pId_genero { get => id_genero; set => id_genero = value; }
        public string pGenero { get => genero; set => genero = value; }

        public DataTable MostrarGenero()
        {
            DataTable DtResultado = new DataTable("Generos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Mostrar_Genero";
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
