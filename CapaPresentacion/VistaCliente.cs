using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaLogica;

namespace CapaPresentacion
{
    public partial class VistaCliente : Form
    {
        public VistaCliente()
        {
            InitializeComponent();
        }

        private void VistaCliente_Load(object sender, EventArgs e)
        {
            this.Mostrarcliente();
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            // this.dataListado.Columns[1].Visible = false;
            // this.datalistado.Columns[7].Visible = false;

        }
        private void Mostrarcliente()
        {
            this.dataListado.DataSource = LClientes.Mostrar();
            this.OcultarColumnas();
            lbltotal.Text = "Cant Clientes Registradas: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void Buscarcliente()
        {
            this.dataListado.DataSource = LClientes.BuscarNombre(this.txtbuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Cant Clientes Registradas: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscarcliente();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            Ventas form = Ventas.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["id_cliente"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            form.setCliente(par1, par2);
            this.Hide();
        }
    }
}
