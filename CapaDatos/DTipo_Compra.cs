using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
  public  class DTipo_Compra
    {
        private int id_tipo;
        private string compra;

        public DTipo_Compra(int id_tipo, string compra)
        {
            this.id_tipo = id_tipo;
            this.compra = compra;
        }

        public DTipo_Compra()
        {

        }
        public int Id_tipo { get => id_tipo; set => id_tipo = value; }
        public string Compra { get => compra; set => compra = value; }

        public DataTable MostrarTipo_Compra()
        {
            DataTable DtResultado = new DataTable("Tipos_Compras");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Combo_TipoCompra";
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
