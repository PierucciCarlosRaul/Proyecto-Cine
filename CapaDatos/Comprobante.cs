using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
  public class Comprobante
    {
        private int id_comprobante;
        private DateTime fecha;
        private int id_personal;
        private int id_cliente;
        private string textobuscar;


        public int Id_comprobante { get => id_comprobante; set => id_comprobante = value; }
        public int Id_personal { get => id_personal; set => id_personal = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Id_cliente { get => id_cliente; set => id_cliente = value; }

        public string Textobuscar { get => textobuscar; set => textobuscar = value; }

        public Comprobante() { }

        public Comprobante(int id_comprobante, DateTime fecha,int id_personal, int id_cliente, string textobuscar) {

            this.Id_comprobante = id_comprobante;
            this.Fecha = fecha;
            this.Id_personal = id_personal;
            this.Id_cliente = id_cliente;
            this.Textobuscar = textobuscar;
        }

        public string Insertar_Comprobante(Comprobante comprobante)
       {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = conexion.CadenaConexion;
                sqlcon.Open();

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;

                sqlcmd.CommandText = "Insertar_Comprobante";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parfecha = new SqlParameter();
                parfecha.ParameterName = "@fecha";
                parfecha.SqlDbType = SqlDbType.Date;
                parfecha.Value = comprobante.Fecha;
                sqlcmd.Parameters.Add(parfecha);


                SqlParameter parpersonal = new SqlParameter();
                parpersonal.ParameterName = "@id_personal";
                parpersonal.SqlDbType = SqlDbType.Int;
                parpersonal.Value = comprobante.Id_personal;
                sqlcmd.Parameters.Add(parpersonal);

                SqlParameter parcliente = new SqlParameter();
                parcliente.ParameterName = "@id_cliente";
                parcliente.SqlDbType = SqlDbType.Int;
                parcliente.Value = comprobante.Id_cliente;
                sqlcmd.Parameters.Add(parcliente);

                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

                
            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }
            return rpta;
        }

        public string EliminarComprobante(Comprobante comprobante)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = conexion.CadenaConexion;
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "Eliminar_Comprobante";
                sqlcmd.CommandType = CommandType.StoredProcedure;



                SqlParameter paridcomprobante = new SqlParameter();
                paridcomprobante.ParameterName = "@id_comprobante";
                paridcomprobante.SqlDbType = SqlDbType.Int;
                paridcomprobante.Value = comprobante.Id_comprobante;
                sqlcmd.Parameters.Add(paridcomprobante);



                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "NO se pudo Eliminar el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }
            return rpta;

        }


        public DataTable MostrarComprobantes()
        {
            DataTable DtResultado = new DataTable("Comprobantes");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "MostrarComprobante";
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

        public DataTable BuscarComprobante(Comprobante comprobante)
        {
            DataTable DtResultado = new DataTable("Comprobantes");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "BuscarComprobante";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 70;
                ParTextoBuscar.Value = comprobante.Textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

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
