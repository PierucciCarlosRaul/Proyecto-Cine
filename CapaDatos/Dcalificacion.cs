using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Dcalificacion
    {
        private int id_calificacion;
        private string calificacion;

        public Dcalificacion(int id_calificacion, string calificacion)
        {
            this.id_calificacion = id_calificacion;
            this.calificacion = calificacion;
        }

        public Dcalificacion()
        {

        }
        public int pId_calificacion { get => id_calificacion; set => id_calificacion = value; }
        public string pCalificacion { get => calificacion; set => calificacion = value; }

        public DataTable MostrarCalificaciones()
        {
            DataTable DtResultado = new DataTable("Calificaciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Mostrar_Calificacion";
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
