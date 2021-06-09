using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaLogica
{
  public  class LcomboPago
    {
        public static DataTable MostrarComboPago()
        {
            return new DcomboPago().MostrarComboPago(); ;
        }
    }
}
