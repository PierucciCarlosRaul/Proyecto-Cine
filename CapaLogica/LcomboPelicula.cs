using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaLogica
{
    public class LcomboPelicula
    {
        public static DataTable MostrarComboPelicula()
        {
            return new DComboPelicula().MostrarComboPelicula();
        }
    }
}
