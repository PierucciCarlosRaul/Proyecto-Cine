using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
   public class DBarrio
    {
        private int id_barrio;
        private string barrio;

        public DBarrio(int id_barrio, string barrio)
        {
            this.id_barrio = id_barrio;
            this.barrio = barrio;
        }

        public DBarrio()
        {

        }
        public int pId_barrio { get => id_barrio; set => id_barrio = value; }
        public string pBarrio { get => barrio; set => barrio = value; }

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Barrios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrar_barrio";
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

