using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
   public class DFuncion
   {
        private int id_funcion;
        private string funcion;

        public DFuncion(int id_funcion, string funcion)
        {
            this.id_funcion = id_funcion;
            this.funcion = funcion;
        }

        public DFuncion()
        {

        }
        public int Id_funcion { get => id_funcion; set => id_funcion = value; }
        public string Funcion { get => funcion; set => funcion = value; }

        public DataTable MostrarFuncion()
        {
            DataTable DtResultado = new DataTable("Funciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Combo_Funciones";
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

