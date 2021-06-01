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

        public int Id_comprobante { get => id_comprobante; set => id_comprobante = value; }
        public int Id_personal { get => id_personal; set => id_personal = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Id_cliente { get => id_cliente; set => id_cliente = value; }

        public Comprobante() { }

        public Comprobante(int id_comprobante, DateTime fecha,int id_personal, int id_cliente) {

            this.Id_comprobante = id_comprobante;
            this.Fecha = fecha;
            this.Id_personal = id_personal;
            this.Id_cliente = id_cliente;
        }

        public string Insertar_Comprobante(Comprobante comprobante, List<Ddetalle_Comprobante> detalle)
       {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = conexion.CadenaConexion;
                sqlcon.Open();
                SqlTransaction SqlTra = sqlcon.BeginTransaction();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.Transaction = SqlTra;
                sqlcmd.CommandText = "Insertar_Comprobante";
                sqlcmd.CommandType = CommandType.StoredProcedure;
                
                SqlParameter parid_comprobante = new SqlParameter();
                parid_comprobante.ParameterName = "@id_comprobante";
                parid_comprobante.SqlDbType = SqlDbType.Int;
                parid_comprobante.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(parid_comprobante);

                SqlParameter parfecha = new SqlParameter();
                parfecha.ParameterName = "@fecha";
                parfecha.SqlDbType = SqlDbType.Date;
                parfecha.Value = comprobante.Fecha;
                sqlcmd.Parameters.Add(parfecha);


                SqlParameter parpersonal = new SqlParameter();
                parpersonal.ParameterName = "@id_personal";
                parpersonal.SqlDbType = SqlDbType.Date;
                parpersonal.Value = comprobante.Id_personal;
                sqlcmd.Parameters.Add(parpersonal);

                SqlParameter parcliente = new SqlParameter();
                parcliente.ParameterName = "@id_cliente";
                parcliente.SqlDbType = SqlDbType.Date;
                parcliente.Value = comprobante.Id_cliente;
                sqlcmd.Parameters.Add(parcliente);
                
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

                if (rpta.Equals("OK"))
                {
                    this.Id_comprobante = Convert.ToInt32(sqlcmd.Parameters["@id_comprobante"]);
                    foreach (Ddetalle_Comprobante det in detalle) 
                    {
                        det.Id_comprobante = this.Id_comprobante;
                        rpta = det.Insertar_Detalle_Comprobante(det, ref sqlcon, ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                if (rpta.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                else { SqlTra.Rollback(); }

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




    }
}
