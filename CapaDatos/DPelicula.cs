using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPelicula
        {
            int id_pelicula;
            string nombre;
            string argumento;
            DateTime estreno;
            int duracion;
            int id_idioma;
            int id_clasificacion;
            int id_calificacion;
           int id_genero;
           string textobuscar;

            public DPelicula()
            {
                this.nombre = "";
                this.argumento = "";
                this.estreno = DateTime.Now; 
                this.duracion = 0;
                this.id_idioma = 0;
                this.id_clasificacion = 0;
                this.id_calificacion = 0;
                this.id_genero = 0;
            
                this.textobuscar = "";
            }

        

            public DPelicula(string nombre, string argumento, DateTime estreno, int duracion, int id_idioma, int id_clasificacion, int id_calificacion, int id_genero, string textobuscar)
            {
            this.nombre = nombre;
            this.argumento = argumento;
            this.estreno = estreno;
            this.duracion = duracion;
            this.id_idioma = id_idioma;
            this.id_clasificacion = id_clasificacion;
            this.id_calificacion = id_calificacion;
            this.id_genero = id_genero;

            this.textobuscar = textobuscar;
        }
            public int pId_pelicula { get => id_pelicula; set => id_pelicula = value; }
            public string pNombre { get => nombre; set => nombre = value; }
            public string pArgumento { get => argumento; set => argumento = value; }
            public DateTime pEstreno { get => estreno; set => estreno = value; }
            public int pDuracion { get => duracion; set => duracion = value; }
            public int pId_idioma { get => id_idioma; set => id_idioma = value; }
            public int pId_clasificacion { get => id_clasificacion; set => id_clasificacion = value; }
            public int pId_calificacion { get => id_calificacion; set => id_calificacion = value; }
            public int pId_genero { get => id_genero; set => id_genero = value; }
            public string pTextobuscar { get => textobuscar; set => textobuscar = value; }
        
        public string InsertarPelicula(DPelicula peliculas)
            {

                string rpta = "";
                SqlConnection sqlcon = new SqlConnection();
                try
                {
                    sqlcon.ConnectionString = conexion.CadenaConexion;
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.CommandText = "insertarpelicula";
                    sqlcmd.CommandType = CommandType.StoredProcedure;

                    //SqlParameter parid_cliente = new SqlParameter();
                    //parid_cliente.ParameterName = "@id_cliente";
                    //parid_cliente.SqlDbType = SqlDbType.Int;
                    //parid_cliente.Direction = ParameterDirection.Output;

                    SqlParameter parnombre = new SqlParameter();
                    parnombre.ParameterName = "@nombre";
                    parnombre.SqlDbType = SqlDbType.VarChar;
                    parnombre.Size = 32;
                    parnombre.Value = peliculas.nombre;
                    sqlcmd.Parameters.Add(parnombre);


                    SqlParameter parargumento = new SqlParameter();
                    parargumento.ParameterName = "@argumento";
                    parargumento.SqlDbType = SqlDbType.VarChar;
                    parargumento.Size = 32;
                    parargumento.Value = peliculas.argumento; ;
                    sqlcmd.Parameters.Add(parargumento);

                SqlParameter parestreno = new SqlParameter();
                parestreno.ParameterName = "@estreno";
                parestreno.SqlDbType = SqlDbType.DateTime;
                parestreno.Value = peliculas.estreno;
                sqlcmd.Parameters.Add(parestreno);

                SqlParameter parduracion = new SqlParameter();
                parduracion.ParameterName = "@duracion";
                parduracion.SqlDbType = SqlDbType.VarChar;
                parduracion.Value = peliculas.duracion;
                sqlcmd.Parameters.Add(parduracion);

                SqlParameter paridioma = new SqlParameter();
                paridioma.ParameterName = "@id_idioma";
                paridioma.SqlDbType = SqlDbType.VarChar;
                paridioma.Value = peliculas.id_idioma; 
                sqlcmd.Parameters.Add(paridioma);

                SqlParameter parclasificacion = new SqlParameter();
                parclasificacion.ParameterName = "@id_clasificacion";
                parclasificacion.SqlDbType = SqlDbType.VarChar;
                parclasificacion.Value = peliculas.id_clasificacion; 
                    sqlcmd.Parameters.Add(parclasificacion);

                SqlParameter parcalificacion = new SqlParameter();
                parcalificacion.ParameterName = "@id_calificacion";
                parcalificacion.SqlDbType = SqlDbType.VarChar;
                parcalificacion.Value = peliculas.id_calificacion;
                sqlcmd.Parameters.Add(parcalificacion);

                SqlParameter pargenero = new SqlParameter();
                pargenero.ParameterName = "@id_genero";
                pargenero.SqlDbType = SqlDbType.VarChar;
                pargenero.Value = peliculas.id_genero;
                sqlcmd.Parameters.Add(pargenero);
                
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



            public string EditarPelicula(DPelicula peliculas)
            {

                string rpta = "";
                SqlConnection sqlcon = new SqlConnection();
                try
                {
                    sqlcon.ConnectionString = conexion.CadenaConexion;
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.CommandText = "editarpelicula";
                    sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parid_pelicula = new SqlParameter();
                parid_pelicula.ParameterName = "@id_pelicula";
                parid_pelicula.SqlDbType = SqlDbType.Int;
                parid_pelicula.Value = peliculas.id_pelicula;
                sqlcmd.Parameters.Add(parid_pelicula);

                SqlParameter parnombre = new SqlParameter();
                parnombre.ParameterName = "@nombre";
                parnombre.SqlDbType = SqlDbType.VarChar;
                parnombre.Size = 32;
                parnombre.Value = peliculas.nombre;
                sqlcmd.Parameters.Add(parnombre);


                SqlParameter parargumento = new SqlParameter();
                parargumento.ParameterName = "@argumento";
                parargumento.SqlDbType = SqlDbType.VarChar;
                parargumento.Size = 32;
                parargumento.Value = peliculas.argumento; ;
                sqlcmd.Parameters.Add(parargumento);

                SqlParameter parestreno = new SqlParameter();
                parestreno.ParameterName = "@estreno";
                parestreno.SqlDbType = SqlDbType.DateTime;
                parestreno.Value = peliculas.estreno;
                sqlcmd.Parameters.Add(parestreno);

                SqlParameter parduracion = new SqlParameter();
                parduracion.ParameterName = "@duracion";
                parduracion.SqlDbType = SqlDbType.VarChar;
                parduracion.Value = peliculas.duracion;
                sqlcmd.Parameters.Add(parduracion);

                SqlParameter paridioma = new SqlParameter();
                paridioma.ParameterName = "@id_idioma";
                paridioma.SqlDbType = SqlDbType.VarChar;
                paridioma.Value = peliculas.id_idioma;
                sqlcmd.Parameters.Add(paridioma);

                SqlParameter parclasificacion = new SqlParameter();
                parclasificacion.ParameterName = "@id_clasificacion";
                parclasificacion.SqlDbType = SqlDbType.VarChar;
                parclasificacion.Value = peliculas.id_clasificacion;
                sqlcmd.Parameters.Add(parclasificacion);

                SqlParameter parcalificacion = new SqlParameter();
                parcalificacion.ParameterName = "@id_calificacion";
                parcalificacion.SqlDbType = SqlDbType.VarChar;
                parcalificacion.Value = peliculas.id_calificacion;
                sqlcmd.Parameters.Add(parcalificacion);

                SqlParameter pargenero = new SqlParameter();
                pargenero.ParameterName = "@id_genero";
                pargenero.SqlDbType = SqlDbType.VarChar;
                pargenero.Value = peliculas.id_genero;
                sqlcmd.Parameters.Add(pargenero);

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

            public string EliminarPelicula(DPelicula peliculas)
            {
                string rpta = "";
                SqlConnection sqlcon = new SqlConnection();
                try
                {
                    sqlcon.ConnectionString = conexion.CadenaConexion;
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.CommandText = "eliminarpelicula";
                    sqlcmd.CommandType = CommandType.StoredProcedure;



                SqlParameter parid_pelicula = new SqlParameter();
                parid_pelicula.ParameterName = "@id_pelicula";
                parid_pelicula.SqlDbType = SqlDbType.Int;
                parid_pelicula.Value = peliculas.id_pelicula;
                sqlcmd.Parameters.Add(parid_pelicula);

               

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

            public DataTable MostrarPelicula()
            {
                DataTable DtResultado = new DataTable("Peliculas");
                SqlConnection SqlCon = new SqlConnection();
                try
                {
                    SqlCon.ConnectionString = conexion.CadenaConexion;
                    SqlCommand SqlCmd = new SqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandText = "Mostrarpeliculas";
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

            public DataTable BuscarPelicula(DPelicula peliculas)
            {
                DataTable DtResultado = new DataTable("Peliculas");
                SqlConnection SqlCon = new SqlConnection();
                try
                {
                    SqlCon.ConnectionString = conexion.CadenaConexion;
                    SqlCommand SqlCmd = new SqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandText = "buscar_peliculas";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParTextoBuscar = new SqlParameter();
                    ParTextoBuscar.ParameterName = "@textobuscar";
                    ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                    ParTextoBuscar.Size = 70;
                    ParTextoBuscar.Value = peliculas.textobuscar;
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

