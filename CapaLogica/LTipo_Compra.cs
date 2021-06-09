using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;


namespace CapaLogica
{
    public class LTipo_Compra
    {
        public static DataTable MostrarTipo_Compra()
        {
            return new DTipo_Compra().MostrarTipo_Compra();
        }
    }
}
