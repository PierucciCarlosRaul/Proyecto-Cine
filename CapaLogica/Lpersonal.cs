using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaLogica
{
   public class Lpersonal
    {
        public static string InsertarPersonal(string nombre, string dni, int id_sexo,
            DateTime fecha_nac, string domicilio,
        string email, string telefono, string acceso, string usuario, string password)
        {
            Dpersonal Obj = new Dpersonal();
           
            Obj.Nombre = nombre;
            Obj.Dni = dni;
            Obj.Id_sexo = id_sexo;
            Obj.Fecha_nac = fecha_nac;
            Obj.Domicilio = domicilio;
            Obj.Email = email;
            Obj.Telefono = telefono;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            
            return Obj.InsertarPersonal(Obj);
        }

        public static string EditarPersonal(int id_personal,string nombre, string dni, int id_sexo,
            DateTime fecha_nac, string domicilio,
        string email, string telefono, string acceso, string usuario, string password)
        {
            Dpersonal Obj = new Dpersonal();
            Obj.Id_personal = id_personal;
            Obj.Nombre = nombre;
            Obj.Dni = dni;
            Obj.Id_sexo = id_sexo;
            Obj.Fecha_nac = fecha_nac;
            Obj.Domicilio = domicilio;
            Obj.Email = email;
            Obj.Telefono = telefono;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            
            return Obj.EditarPersonal(Obj);
        }


        public static string EliminarPersonal(int id_personal)
        {
            Dpersonal Obj = new Dpersonal();
            Obj.Id_personal = id_personal;
            return Obj.EliminarPersonal(Obj);
        }
        public static DataTable Mostrarpersonal()
        {
            return new Dpersonal().Mostrarpersonal();
        }
        public static DataTable BuscarPersonal(string textobuscar)
        {
            Dpersonal Obj = new Dpersonal();
            Obj.Textobuscar = textobuscar;
            return Obj.BuscarPersonal(Obj);
        }

        public static DataTable Login(string usuario , string password)
        {
            Dpersonal Obj = new Dpersonal();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }


    }
}
