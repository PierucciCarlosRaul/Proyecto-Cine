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
        public static string Insertar_Comprobante( DateTime fecha, int id_personal, int id_cliente)
        {
            Comprobante Obj = new Comprobante();
            Obj.Fecha = fecha;
            Obj.Id_personal = id_personal;
            Obj.Id_cliente = id_cliente;
            
            return Obj.Insertar_Comprobante(Obj);
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
