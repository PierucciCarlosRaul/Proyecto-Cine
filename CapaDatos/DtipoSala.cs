using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;


namespace CapaDatos
{
    public class DtipoSala
    {
            private int id_tipo_sala;
            private string tipo_sala;

            public DtipoSala(int id_tipo_sala, string tipo_sala)
            {
                this.id_tipo_sala = id_tipo_sala;
                this.tipo_sala = tipo_sala;
            }

            public DtipoSala()
            {

            }
            public int Id_tipo_sala { get => id_tipo_sala; set => id_tipo_sala = value; }
            public string Tipo_sala { get => tipo_sala; set => tipo_sala = value; }

            public DataTable MostrarTipoSala()
            {
                DataTable DtResultado = new DataTable("Tipos_Salas");
                SqlConnection SqlCon = new SqlConnection();
                try
                {
                    SqlCon.ConnectionString = conexion.CadenaConexion;
                    SqlCommand SqlCmd = new SqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandText = "Combo_Tiposala";
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
        }
    }

