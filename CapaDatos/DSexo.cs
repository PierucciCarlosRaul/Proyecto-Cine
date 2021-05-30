using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
  public  class DSexo
    {
        private int id_sexo;
        private string sexo;

        public DSexo(int id_sexo, string sexo)
        {
            this.id_sexo = id_sexo;
            this.sexo = sexo;
        }

        public DSexo()
        {

        }
        public int Id_sexo { get => id_sexo; set => id_sexo = value; }
        public string Sexo { get => sexo; set => sexo = value; }

        public DataTable MostrarSexo()
        {
            DataTable DtResultado = new DataTable("Sexo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrar_sexo";
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

