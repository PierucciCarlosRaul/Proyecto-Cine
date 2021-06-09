using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
   public class DcomboSala
    {
        private int id_sala;
        private string sala;

        public DcomboSala(int id_sala, string sala)
        {
            this.id_sala = id_sala;
            this.sala = sala;
        }

        public DcomboSala()
        {

        }
        public int Id_sala { get => id_sala; set => id_sala = value; }
        public string Sala { get => sala; set => sala = value; }

        public DataTable MostrarComboSala()
        {
            DataTable DtResultado = new DataTable("Salas");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Combo_NroSala";
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
