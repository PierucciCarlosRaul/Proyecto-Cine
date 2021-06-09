using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;


namespace CapaLogica
{
  public class LcomboSala
    {
        public static DataTable MostrarComboSala()
        {
            return new DcomboSala().MostrarComboSala();
        }
    }
}
