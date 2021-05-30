using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using System.Data;


namespace CapaLogica
{
   public class LClientes
    {
        public static string Insertar(string nombre, string dni, int id_barrio, int id_tipos_cliente,
                                    string telefono, string email)
        {
            DClientes Obj = new DClientes();
            Obj.pNombre = nombre;
            Obj.Dni = dni;
            Obj.pId_barrio = id_barrio;
            Obj.pId_tipos_cliente = id_tipos_cliente;
            Obj.pTelefono = telefono;
            Obj.pEmail = email;
           

            return Obj.insertar(Obj);
        }

        public static string Editar(int id_cliente,string nombre, string dni, int id_barrio, int id_tipos_cliente,
                                    string telefono, string email)
        {
            DClientes Obj = new DClientes();
            Obj.pId_cliente = id_cliente;
            Obj.pNombre = nombre;
            Obj.Dni = dni;
            Obj.pId_barrio = id_barrio;
            Obj.pId_tipos_cliente = id_tipos_cliente;
            Obj.pTelefono = telefono;
            Obj.pEmail = email;
            return Obj.editar(Obj);
        }

        public static string Eliminar(int id_cliente)
        {
            DClientes Obj = new DClientes();
            Obj.pId_cliente = id_cliente;
            return Obj.eliminar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DClientes().Mostrar();
        }
        public static DataTable BuscarNombre(string textobuscar)
        {
            DClientes Obj = new DClientes();
            Obj.pTextobuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}

