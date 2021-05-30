using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using System.Data;

namespace CapaLogica
{
  public  class LPelicula
    {
        public static string InsertarPelicula(string nombre, string argumento, DateTime estreno, int duracion, 
            int id_idioma, int id_clasificacion, int id_calificacion, int id_genero)
        {
            DPelicula Obj = new DPelicula();
            Obj.pNombre = nombre;
            Obj.pArgumento = argumento;
            Obj.pEstreno = estreno;
            Obj.pDuracion = duracion;
            Obj.pId_idioma = id_idioma;
            Obj.pId_clasificacion = id_clasificacion;
            Obj.pId_calificacion = id_calificacion;
            Obj.pId_genero = id_genero;


            return Obj.InsertarPelicula(Obj);
        }

        public static string EditarPelicula(int id_pelicula, string nombre, string argumento, DateTime estreno, int duracion,
            int id_idioma, int id_clasificacion, int id_calificacion, int id_genero)
        {
            DPelicula Obj = new DPelicula();
            Obj.pId_pelicula = id_pelicula;
            Obj.pNombre = nombre;
            Obj.pArgumento = argumento;
            Obj.pEstreno = estreno;
            Obj.pDuracion = duracion;
            Obj.pId_idioma = id_idioma;
            Obj.pId_clasificacion = id_clasificacion;
            Obj.pId_calificacion = id_calificacion;
            Obj.pId_genero = id_genero;
            return Obj.EditarPelicula(Obj);
        }

        public static string EliminarPelicula(int id_pelicula)
        {
            DPelicula Obj = new DPelicula();
            Obj.pId_pelicula = id_pelicula;
            return Obj.EliminarPelicula(Obj);
        }
        public static DataTable MostrarPelicula()
        {
            return new DPelicula().MostrarPelicula();
        }
        public static DataTable BuscarPelicula(string textobuscar)
        {
            DPelicula Obj = new DPelicula();
            Obj.pTextobuscar = textobuscar;
            return Obj.BuscarPelicula(Obj);
        }
    }


}

