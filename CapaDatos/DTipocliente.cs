using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
   public class DTipocliente
    {
        private int id_tipos_cliente;
        private string tipos_cliente;

        public DTipocliente(int id_tipos_cliente, string tipos_cliente)
        {
            this.id_tipos_cliente = id_tipos_cliente;
            this.tipos_cliente = tipos_cliente;
        }
        public DTipocliente()
        {

        }

        public int Id_tipos_cliente { get => id_tipos_cliente; set => id_tipos_cliente = value; }
        public string Tipos_cliente { get => tipos_cliente; set => tipos_cliente = value; }

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Tipos_Clientes");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrar_tipocliente";
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

