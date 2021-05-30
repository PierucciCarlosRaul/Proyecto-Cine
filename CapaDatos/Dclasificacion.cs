using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Dclasificacion
    {
        private int id_clasificacion;
        private string clasificacion;

        public Dclasificacion(int id_clasificacion, string clasificacion)
        {
            this.id_clasificacion = id_clasificacion;
            this.clasificacion = clasificacion;
        }

        public Dclasificacion()
        {

        }
        public int pId_clasificacion { get => id_clasificacion; set => id_clasificacion = value; }
        public string pClasificacion { get => clasificacion; set => clasificacion = value; }

        public DataTable MostrarClasificaciones()
        {
            DataTable DtResultado = new DataTable("Clasificaciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Mostrar_Clasificaciones";
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
