using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
  public  class DClientes
    {
        int id_cliente;
        string nombre;
        string dni;
        int id_barrio;
        int id_tipos_cliente;
        string Telefono;
        string Email;
        string textobuscar;

        public DClientes()
        {
            this.nombre = "";
            this.dni = "";
            this.id_barrio = 0;
            this.id_tipos_cliente = 0;
            this.Telefono = "";
            this.Email = "";
            this.textobuscar = "";
        }

        //public Clientes()
        //{

        //}

        public DClientes(string nombre, string dni, int id_barrio, int id_tipos_cliente, string Telefono, string Email, string textobuscar)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.id_barrio = id_barrio;
            this.id_tipos_cliente = id_tipos_cliente;
            this.Telefono = Telefono;
            this.Email = Email;
            this.textobuscar = textobuscar;
        }
        public int pId_cliente { get => id_cliente; set => id_cliente = value; }
        public string pNombre { get => nombre; set => nombre = value; }
        public string Dni { get => dni; set => dni = value; }
        public int pId_tipos_cliente { get => id_tipos_cliente; set => id_tipos_cliente = value; }
        public int pId_barrio { get => id_barrio; set => id_barrio = value; }
        public string pTelefono { get => Telefono; set => Telefono = value; }
        public string pEmail { get => Email; set => Email = value; }
        public string pTextobuscar { get => textobuscar; set => textobuscar = value; }

        public string insertar(DClientes clientes)
        {

            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = conexion.CadenaConexion;
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "insertar";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter parid_cliente = new SqlParameter();
                //parid_cliente.ParameterName = "@id_cliente";
                //parid_cliente.SqlDbType = SqlDbType.Int;
                //parid_cliente.Direction = ParameterDirection.Output;

                SqlParameter parnombre = new SqlParameter();
                parnombre.ParameterName = "@nombre";
                parnombre.SqlDbType = SqlDbType.VarChar;
                parnombre.Size = 70;
                parnombre.Value = clientes.nombre;
                sqlcmd.Parameters.Add(parnombre);


                SqlParameter pardni = new SqlParameter();
                pardni.ParameterName = "@dni";
                pardni.SqlDbType = SqlDbType.VarChar;
                pardni.Size = 70;
                pardni.Value = clientes.dni;
                sqlcmd.Parameters.Add(pardni);

                SqlParameter parid_barrio = new SqlParameter();
                parid_barrio.ParameterName = "@id_barrio";
                parid_barrio.SqlDbType = SqlDbType.VarChar;
                parid_barrio.Value = clientes.id_barrio;
                sqlcmd.Parameters.Add(parid_barrio);

                SqlParameter parId_tipos_cliente = new SqlParameter();
                parId_tipos_cliente.ParameterName = "@id_tipos_cliente";
                parId_tipos_cliente.SqlDbType = SqlDbType.VarChar;
                parId_tipos_cliente.Value = clientes.pId_tipos_cliente;
                sqlcmd.Parameters.Add(parId_tipos_cliente);

                SqlParameter partelefono = new SqlParameter();
                partelefono.ParameterName = "@telefono";
                partelefono.SqlDbType = SqlDbType.VarChar;
                partelefono.Size = 70;
                partelefono.Value = clientes.Telefono;
                sqlcmd.Parameters.Add(partelefono);

                SqlParameter paremail = new SqlParameter();
                paremail.ParameterName = "@email";
                paremail.SqlDbType = SqlDbType.VarChar;
                paremail.Size = 70;
                paremail.Value = clientes.Email;
                sqlcmd.Parameters.Add(paremail);

                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }
            return rpta;
        }



        public string editar(DClientes clientes)
        {

            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = conexion.CadenaConexion;
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "editar";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parid_cliente = new SqlParameter();
                parid_cliente.ParameterName = "@id_cliente";
                parid_cliente.SqlDbType = SqlDbType.Int;
                parid_cliente.Value = clientes.id_cliente;
                sqlcmd.Parameters.Add(parid_cliente);

                SqlParameter parnombre = new SqlParameter();
                parnombre.ParameterName = "@nombre";
                parnombre.SqlDbType = SqlDbType.VarChar;
                parnombre.Size = 70;
                parnombre.Value = clientes.nombre;
                sqlcmd.Parameters.Add(parnombre);


                SqlParameter pardni = new SqlParameter();
                pardni.ParameterName = "@dni";
                pardni.SqlDbType = SqlDbType.VarChar;
                pardni.Size = 70;
                pardni.Value = clientes.dni;
                sqlcmd.Parameters.Add(pardni);

                SqlParameter parid_barrio = new SqlParameter();
                parid_barrio.ParameterName = "@id_barrio";
                parid_barrio.SqlDbType = SqlDbType.VarChar;
                parid_barrio.Value = clientes.id_barrio;
                sqlcmd.Parameters.Add(parid_barrio);

                SqlParameter parId_tipos_cliente = new SqlParameter();
                parId_tipos_cliente.ParameterName = "@id_tipos_cliente";
                parId_tipos_cliente.SqlDbType = SqlDbType.VarChar;
                parId_tipos_cliente.Value = clientes.pId_tipos_cliente;
                sqlcmd.Parameters.Add(parId_tipos_cliente);

                SqlParameter partelefono = new SqlParameter();
                partelefono.ParameterName = "@telefono";
                partelefono.SqlDbType = SqlDbType.VarChar;
                partelefono.Size = 70;
                partelefono.Value = clientes.Telefono;
                sqlcmd.Parameters.Add(partelefono);

                SqlParameter paremail = new SqlParameter();
                paremail.ParameterName = "@email";
                paremail.SqlDbType = SqlDbType.VarChar;
                paremail.Size = 70;
                paremail.Value = clientes.Email;
                sqlcmd.Parameters.Add(paremail);

                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Modifico el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }
            return rpta;

        }

        public string eliminar(DClientes clientes)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = conexion.CadenaConexion;
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "eliminar";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parid_cliente = new SqlParameter();
                parid_cliente.ParameterName = "@id_cliente";
                parid_cliente.SqlDbType = SqlDbType.Int;
                parid_cliente.Value = clientes.id_cliente;
                sqlcmd.Parameters.Add(parid_cliente);

                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "NO se pudo Eliminar el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }
            return rpta;

        }

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Clientes");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Mostrar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        public DataTable BuscarNombre(DClientes Cliente)
        {
            DataTable DtResultado = new DataTable("Clientes");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 70;
                ParTextoBuscar.Value = Cliente.textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
