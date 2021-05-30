using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
namespace CapaLogica
{
    public class Lclasificacion
    {
        public static DataTable MostrarClasificaciones()
        {
            return new Dclasificacion().MostrarClasificaciones();
        }
    }
}
