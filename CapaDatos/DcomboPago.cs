using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
  public  class DcomboPago
    {
        private int id_pago;
        private string pago;

        public DcomboPago(int id_pago, string pago)
        {
            this.id_pago = id_pago;
            this.pago = pago;
        }

        public DcomboPago()
        {

        }
        public int Id_pago { get => id_pago; set => id_pago = value; }
        public string Pago { get => pago; set => pago = value; }

        public DataTable MostrarComboPago()
        {
            DataTable DtResultado = new DataTable("Formas_Pagos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Combo_Pago";
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
