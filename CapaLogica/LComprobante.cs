using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaLogica
{
   public class LComprobante
    {
        public static string Insertar_Comprobante( DateTime fecha, int id_personal, int id_cliente ,DataTable dtDetalle )
        {
            Comprobante Obj = new Comprobante();
            Obj.Fecha = fecha;
            Obj.Id_personal = id_personal;
            Obj.Id_cliente = id_cliente;
            List<Ddetalle_Comprobante> detalle = new List<Ddetalle_Comprobante>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                Ddetalle_Comprobante detalles = new Ddetalle_Comprobante();
                detalles.Monto = Convert.ToDouble(row["monto"].ToString());
                detalles.Descuento = Convert.ToDouble(row["descuento"].ToString());
                detalles.Id_funcion = Convert.ToInt32(row["id_funcion"].ToString());
                detalles.Id_butaca = Convert.ToInt32(row["id_butaca"].ToString());
                detalles.Id_tipo_compra = Convert.ToInt32(row["id_tipo_compra"].ToString());
                detalles.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalles.Id_pelicula = Convert.ToInt32(row["id_pelicula"].ToString());
                detalles.Id_forma_pago = Convert.ToInt32(row["id_forma_pago"].ToString());
                detalles.Id_sala = Convert.ToInt32(row["id_sala"].ToString());
                detalles.Id_tipo_sala = Convert.ToInt32(row["id_tipo_sala"].ToString());
                detalles.Id_comprobante = Convert.ToInt32(row["id_comprobante"].ToString());
                detalle.Add(detalles);
            }
            return Obj.Insertar_Comprobante(Obj,detalle);
        }

        public static string EliminarComprobante(int id_comprobante)
        {
            Comprobante Obj = new Comprobante();
            Obj.Id_comprobante = id_comprobante;
            return Obj.EliminarComprobante(Obj);
        }

        public static DataTable BuscarComprobante(string textobuscar)
        {
            Comprobante Obj = new Comprobante();
            Obj.Textobuscar = textobuscar;
            return Obj.BuscarComprobante(Obj);
        }

        public static DataTable MostrarComprobantes()
        {
            return new Comprobante().MostrarComprobantes(); ;
        }
    }
}
