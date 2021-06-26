using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaLogica
{
 public class LDetalle_Comprobante
    {
        

        public LDetalle_Comprobante(double monto, double descuento,
           int id_funcion, int id_butaca, int id_tipo_compra, int cantidad, int id_pelicula,
           int id_forma_pago, int id_sala, int id_tipo_sala, int id_comprobante)
        {

            Ddetalle_Comprobante Obj = new Ddetalle_Comprobante();
            Obj.Monto = monto;
            Obj.Descuento = descuento;
            Obj.Id_funcion = id_funcion;
            Obj.Id_butaca = id_butaca;
            Obj.Id_tipo_compra = id_tipo_compra;
            Obj.Cantidad = cantidad;
            Obj.Id_pelicula = id_pelicula;
            Obj.Id_forma_pago = id_forma_pago;
            Obj.Id_sala = id_sala;
            Obj.Id_tipo_sala = id_tipo_sala;
            Obj.Id_comprobante = id_comprobante;
        
        }

    /*    public static string Insertar_Detalle_Comprobante(double monto, double descuento,
           int id_funcion, int id_butaca, int id_tipo_compra, int cantidad, int id_pelicula,
           int id_forma_pago, int id_sala, int id_tipo_sala, int id_comprobante)
        {
            Ddetalle_Comprobante Obj = new Ddetalle_Comprobante();
            Obj.Monto = monto;
            Obj.Descuento = descuento;
            Obj.Id_funcion = id_funcion;
            Obj.Id_butaca = id_butaca;
            Obj.Id_tipo_compra = id_tipo_compra;
            Obj.Cantidad = cantidad;
            Obj.Id_pelicula = id_pelicula;
            Obj.Id_forma_pago = id_forma_pago;
            Obj.Id_sala = id_sala;
            Obj.Id_tipo_sala = id_tipo_sala;
            Obj.Id_comprobante = id_comprobante;


            return Obj.InsertarDetalleComprobante(Obj);
        }*/


        public static double calcularmonto()
        {
            Ddetalle_Comprobante Obj = new Ddetalle_Comprobante();
           
            return Obj.calcularmonto();
        }
    }
}
