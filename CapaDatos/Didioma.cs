using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Didioma
    {
        private int id_idioma;
        private string idioma;

        public Didioma(int id_idioma, string idioma)
        {
            this.id_idioma = id_idioma;
            this.idioma = idioma;
        }

        public Didioma()
        {

        }
        public int pId_idioma { get => id_idioma; set => id_idioma = value; }
        public string pIdioma { get => idioma; set => idioma = value; }

        public DataTable MostrarIdioma()
        {
            DataTable DtResultado = new DataTable("Idiomas");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Mostrar_Idiomas";
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
