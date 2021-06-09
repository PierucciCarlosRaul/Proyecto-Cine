using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
  public  class DButacas
    
         {
        private int id_butaca;
        private string butaca;

        public DButacas(int id_butaca, string butaca)
        {
            this.id_butaca = id_butaca;
            this.butaca = butaca;
        }

        public DButacas()
        {

        }
        public int Id_butaca { get => id_butaca; set => id_butaca = value; }
        public string Butaca { get => butaca; set => butaca = value; }

        public DataTable MostrarButacas()
        {
            DataTable DtResultado = new DataTable("Butacas");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Combo_NroButaca";
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

