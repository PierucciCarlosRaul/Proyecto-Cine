using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Dpersonal
    {
        private int id_personal;
        private string nombre;
        private string dni;
        private int id_sexo;
        private DateTime fecha_nac;
        private string domicilio;
        private string email;
        private string telefono;
        private string acceso;
        private string usuario;
        private string password;
        private string textobuscar;

        public int Id_personal { get => id_personal; set => id_personal = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Dni { get => dni; set => dni = value; }
        public int Id_sexo { get => id_sexo; set => id_sexo = value; }
        public DateTime Fecha_nac { get => fecha_nac; set => fecha_nac = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Email { get => email; set => email = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Acceso { get => acceso; set => acceso = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }
        public string Textobuscar { get => textobuscar; set => textobuscar = value; }
        


        public Dpersonal(){}
        
        public Dpersonal(int id_personal, string nombre, string dni, int id_sexo, 
            DateTime fecha_nac ,string domicilio, 
        string email,string telefono,string acceso, string usuario, string password, string textobuscar){

            this.Id_personal = id_personal;
            this.Nombre = nombre;
            this.Dni = dni;
            this.Id_sexo = id_sexo;
            this.Fecha_nac = fecha_nac;
            this.Domicilio = domicilio;
            this.Email = email;
            this.Telefono = telefono;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Password = password;
            this.Textobuscar = textobuscar;
        
        }
        
        public string InsertarPersonal(Dpersonal personal)
        {

            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = conexion.CadenaConexion;
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "insertarpersonal";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parnombre = new SqlParameter();
                parnombre.ParameterName = "@nombre";
                parnombre.SqlDbType = SqlDbType.VarChar;
                parnombre.Size = 70;
                parnombre.Value = personal.nombre;
                sqlcmd.Parameters.Add(parnombre);


                SqlParameter pardni = new SqlParameter();
                pardni.ParameterName = "@dni";
                pardni.SqlDbType = SqlDbType.VarChar;
                pardni.Size = 20;
                pardni.Value = personal.dni; ;
                sqlcmd.Parameters.Add(pardni);
                
                SqlParameter parfecha_nac = new SqlParameter();
                parfecha_nac.ParameterName = "@fecha_nac";
                parfecha_nac.SqlDbType = SqlDbType.DateTime;
                parfecha_nac.Value = personal.fecha_nac;
                sqlcmd.Parameters.Add(parfecha_nac);

                SqlParameter parsexo = new SqlParameter();
                parsexo.ParameterName = "@id_sexo";
                parsexo.SqlDbType = SqlDbType.VarChar;
                parsexo.Value = personal.id_sexo;
                sqlcmd.Parameters.Add(parsexo);

                SqlParameter pardomicilio = new SqlParameter();
                pardomicilio.ParameterName = "@domicilio";
                pardomicilio.SqlDbType = SqlDbType.VarChar;
                pardomicilio.Value = personal.domicilio;
                sqlcmd.Parameters.Add(pardomicilio);

                SqlParameter paremail = new SqlParameter();
                paremail.ParameterName = "@email";
                paremail.SqlDbType = SqlDbType.VarChar;
                paremail.Value = personal.email;
                sqlcmd.Parameters.Add(paremail);

                SqlParameter partelefono = new SqlParameter();
                partelefono.ParameterName = "@telefono";
                partelefono.SqlDbType = SqlDbType.VarChar;
                partelefono.Value = personal.telefono;
                sqlcmd.Parameters.Add(partelefono);

                SqlParameter paracceso = new SqlParameter();
                paracceso.ParameterName = "@acceso";
                paracceso.SqlDbType = SqlDbType.VarChar;
                paracceso.Value = personal.acceso;
                sqlcmd.Parameters.Add(paracceso);

                SqlParameter parusuario = new SqlParameter();
                parusuario.ParameterName = "@usuario";
                parusuario.SqlDbType = SqlDbType.VarChar;
                parusuario.Value = personal.usuario;
                sqlcmd.Parameters.Add(parusuario);

                SqlParameter parpassword = new SqlParameter();
                parpassword.ParameterName = "@password";
                parpassword.SqlDbType = SqlDbType.VarChar;
                parpassword.Value = personal.password;
                sqlcmd.Parameters.Add(parpassword);

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



        public string EditarPersonal(Dpersonal personal)
        {

            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = conexion.CadenaConexion;
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "editarpersonal";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parid_personal = new SqlParameter();
                parid_personal.ParameterName = "@id_personal";
                parid_personal.SqlDbType = SqlDbType.Int;
                parid_personal.Value = personal.id_personal;
                sqlcmd.Parameters.Add(parid_personal);

                SqlParameter parnombre = new SqlParameter();
                parnombre.ParameterName = "@nombre";
                parnombre.SqlDbType = SqlDbType.VarChar;
                parnombre.Size = 70;
                parnombre.Value = personal.nombre;
                sqlcmd.Parameters.Add(parnombre);


                SqlParameter pardni = new SqlParameter();
                pardni.ParameterName = "@dni";
                pardni.SqlDbType = SqlDbType.VarChar;
                pardni.Size = 20;
                pardni.Value = personal.dni; ;
                sqlcmd.Parameters.Add(pardni);

                SqlParameter parfecha_nac = new SqlParameter();
                parfecha_nac.ParameterName = "@fecha_nac";
                parfecha_nac.SqlDbType = SqlDbType.DateTime;
                parfecha_nac.Value = personal.fecha_nac;
                sqlcmd.Parameters.Add(parfecha_nac);

                SqlParameter parsexo = new SqlParameter();
                parsexo.ParameterName = "@id_sexo";
                parsexo.SqlDbType = SqlDbType.VarChar;
                parsexo.Value = personal.id_sexo;
                sqlcmd.Parameters.Add(parsexo);

                SqlParameter pardomicilio = new SqlParameter();
                pardomicilio.ParameterName = "@domicilio";
                pardomicilio.SqlDbType = SqlDbType.VarChar;
                pardomicilio.Value = personal.domicilio;
                sqlcmd.Parameters.Add(pardomicilio);

                SqlParameter paremail = new SqlParameter();
                paremail.ParameterName = "@email";
                paremail.SqlDbType = SqlDbType.VarChar;
                paremail.Value = personal.email;
                sqlcmd.Parameters.Add(paremail);

                SqlParameter partelefono = new SqlParameter();
                partelefono.ParameterName = "@telefono";
                partelefono.SqlDbType = SqlDbType.VarChar;
                partelefono.Value = personal.telefono;
                sqlcmd.Parameters.Add(partelefono);

                SqlParameter paracceso = new SqlParameter();
                paracceso.ParameterName = "@acceso";
                paracceso.SqlDbType = SqlDbType.VarChar;
                paracceso.Value = personal.acceso;
                sqlcmd.Parameters.Add(paracceso);

                SqlParameter parusuario = new SqlParameter();
                parusuario.ParameterName = "@usuario";
                parusuario.SqlDbType = SqlDbType.VarChar;
                parusuario.Value = personal.usuario;
                sqlcmd.Parameters.Add(parusuario);

                SqlParameter parpassword = new SqlParameter();
                parpassword.ParameterName = "@password";
                parpassword.SqlDbType = SqlDbType.VarChar;
                parpassword.Value = personal.password;
                sqlcmd.Parameters.Add(parpassword);
                
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

        public string EliminarPersonal(Dpersonal personal)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = conexion.CadenaConexion;
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "eliminarpersonal";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parid_personal = new SqlParameter();
                parid_personal.ParameterName = "@id_personal";
                parid_personal.SqlDbType = SqlDbType.Int;
                parid_personal.Value = personal.id_personal;
                sqlcmd.Parameters.Add(parid_personal);
                
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

        public DataTable Mostrarpersonal()
        {
            DataTable DtResultado = new DataTable("Personal");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Mostrarpersonal";
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

        public DataTable BuscarPersonal(Dpersonal personal)
        {
            DataTable DtResultado = new DataTable("Personal");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscar_personal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 70;
                ParTextoBuscar.Value = personal.textobuscar;
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


        public DataTable Login(Dpersonal personal)
        {
            DataTable DtResultado = new DataTable("Personal");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Login";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Parusuario = new SqlParameter();
                Parusuario.ParameterName = "@usuario";
                Parusuario.SqlDbType = SqlDbType.VarChar;
                Parusuario.Size = 50;
                Parusuario.Value = personal.Usuario;
                SqlCmd.Parameters.Add(Parusuario);


                SqlParameter Parpassword = new SqlParameter();
                Parpassword.ParameterName = "@password";
                Parpassword.SqlDbType = SqlDbType.VarChar;
                Parpassword.Size = 50;
                Parpassword.Value = personal.Password;
                SqlCmd.Parameters.Add(Parpassword);




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

