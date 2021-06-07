using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace CapaDatos
{
  public class Ddetalle_Comprobante
    {
        private int id_detalle_comprobante;
        private double monto; 
        private double descuento;
        private int id_funcion;
        private int id_butaca;
        private int id_tipo_compra;
        private int cantidad;
        private int id_pelicula;
        private int id_forma_pago;
        private int id_sala;
        private int id_tipo_sala;
        private int id_comprobante;
        private int res, n1, n2, n3;

    

        public Ddetalle_Comprobante(){}


        public int Id_detalle_comprobante { set { id_detalle_comprobante = value; } get { return id_detalle_comprobante; } }
        public double Monto { set { monto = value; } get { return monto; } }
        public double Descuento { set { descuento = value; } get { return descuento; } }

        public void EnviarParametros(Ddetalle_Comprobante obj)
        {
            this.Monto = monto;
            this.Descuento = descuento;
            this.Id_funcion = id_funcion;
            this.Id_butaca = id_butaca;
            this.Id_tipo_compra = id_tipo_compra;
            this.Cantidad = cantidad;
            this.Id_pelicula = id_pelicula;
            this.Id_forma_pago = id_forma_pago;
            this.Id_sala = id_sala;
            this.Id_tipo_sala = id_tipo_sala;
            this.Id_comprobante = id_comprobante;
        }

        public int Id_funcion { set { id_funcion = value; } get { return id_funcion; } }
        public int Id_butaca { set { id_butaca = value; } get { return id_butaca; } }
        public int Id_tipo_compra { set { id_tipo_compra = value; } get { return id_tipo_compra; } }
        public int Cantidad { set { cantidad = value; } get { return cantidad; } }
        public int Id_pelicula { set { id_pelicula = value; } get { return id_pelicula; } }
        public int Id_forma_pago { set { id_forma_pago = value; } get { return id_forma_pago; } }
        public int Id_sala { set { id_sala = value; } get { return id_sala; } }
        public int Id_tipo_sala { set { id_tipo_sala = value; } get { return id_tipo_sala; } }
        public int Id_comprobante { set { id_comprobante = value; } get { return id_comprobante; } }
       



        public Ddetalle_Comprobante(int id_detalle_comprobante, double monto, double descuento, 
            int id_funcion, int id_butaca, int id_tipo_compra, int cantidad, int id_pelicula,
            int id_forma_pago, int id_sala, int id_tipo_sala, int id_comprobante) {

            this.Id_detalle_comprobante = id_detalle_comprobante;
            this.Monto = monto;
            this.Descuento = descuento;
            this.Id_funcion = id_funcion;
            this.Id_butaca = id_butaca;
            this.Id_tipo_compra = id_tipo_compra;
            this.Cantidad = cantidad;
            this.Id_pelicula = id_pelicula;
            this.Id_forma_pago = id_forma_pago;
            this.Id_sala = id_sala;
            this.Id_tipo_sala = id_tipo_sala;
            this.Id_comprobante = id_comprobante;
        }
        
        public double calcularmonto()
        {
            return 350;
        }

        public string Insertar_Detalle_Comprobante(Ddetalle_Comprobante dcomprobante,
        ref SqlConnection sqlcon, ref SqlTransaction sqlTra)
        {
            string rpta = "";
            try
            {
                sqlcon.ConnectionString = conexion.CadenaConexion;
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.Transaction = sqlTra;
                sqlcmd.CommandText = "Insertar_Detalle_Comprobante";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parid_detalle_comprobante = new SqlParameter();
                parid_detalle_comprobante.ParameterName = "@id_detalle_comprobante";
                parid_detalle_comprobante.SqlDbType = SqlDbType.Int;
                parid_detalle_comprobante.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(parid_detalle_comprobante);
                
                SqlParameter parmonto = new SqlParameter();
                parmonto.ParameterName = "@monto";
                parmonto.SqlDbType = SqlDbType.Float;
                parmonto.Value = dcomprobante.Monto;
                sqlcmd.Parameters.Add(parmonto);

                SqlParameter pardescuento = new SqlParameter();
                pardescuento.ParameterName = "@descuento";
                pardescuento.SqlDbType = SqlDbType.Float;
                pardescuento.Value = dcomprobante.Descuento;
                sqlcmd.Parameters.Add(pardescuento);

                SqlParameter parfuncion = new SqlParameter();
                parfuncion.ParameterName = "@id_funcion";
                parfuncion.SqlDbType = SqlDbType.Int;
                parfuncion.Value = dcomprobante.Id_funcion;
                sqlcmd.Parameters.Add(parfuncion);

                SqlParameter parbutaca = new SqlParameter();
                parbutaca.ParameterName = "@id_butaca";
                parbutaca.SqlDbType = SqlDbType.Int;
                parbutaca.Value = dcomprobante.Id_butaca;
                sqlcmd.Parameters.Add(parbutaca);

                SqlParameter partipocompra = new SqlParameter();
                partipocompra.ParameterName = "@id_tipo_compra";
                partipocompra.SqlDbType = SqlDbType.Int;
                partipocompra.Value = dcomprobante.Id_tipo_compra;
                sqlcmd.Parameters.Add(partipocompra);

                SqlParameter parcantidad = new SqlParameter();
                parcantidad.ParameterName = "@cantidad";
                parcantidad.SqlDbType = SqlDbType.Int;
                parcantidad.Value = dcomprobante.Cantidad;
                sqlcmd.Parameters.Add(parcantidad); 

                SqlParameter parpelicula = new SqlParameter();
                parpelicula.ParameterName = "@id_pelicula";
                parpelicula.SqlDbType = SqlDbType.Int;
                parpelicula.Value = dcomprobante.Id_pelicula;
                sqlcmd.Parameters.Add(parpelicula); 

                SqlParameter parformapago = new SqlParameter();
                parformapago.ParameterName = "@id_forma_pago";
                parformapago.SqlDbType = SqlDbType.Int;
                parformapago.Value = dcomprobante.Id_forma_pago;
                sqlcmd.Parameters.Add(parformapago);

                SqlParameter parsala = new SqlParameter();
                parsala.ParameterName = "@id_sala";
                parsala.SqlDbType = SqlDbType.Int;
                parsala.Value = dcomprobante.Id_sala;
                sqlcmd.Parameters.Add(parsala);

                SqlParameter partiposala = new SqlParameter();
                partiposala.ParameterName = "@id_tipo_sala";
                partiposala.SqlDbType = SqlDbType.Int;
                partiposala.Value = dcomprobante.Id_tipo_sala;
                sqlcmd.Parameters.Add(partiposala);

                SqlParameter parid_comprobante = new SqlParameter();
                parid_comprobante.ParameterName = "@id_comprobante";
                parid_comprobante.SqlDbType = SqlDbType.Int;
                parid_comprobante.Value = dcomprobante.Id_comprobante;
                sqlcmd.Parameters.Add(parid_comprobante);
                
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




    }
}
