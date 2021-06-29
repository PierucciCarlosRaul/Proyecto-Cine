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
    public partial class VistaComprobante : Form
    {
        public VistaComprobante()
        {
            InitializeComponent();
        }

        private void VistaComprobante_Load(object sender, EventArgs e)
        {
            MostrarComprobante();
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            // this.dataListado.Columns[1].Visible = false;
            // this.datalistado.Columns[7].Visible = false;

        }
        private void MostrarComprobante()
        {
            this.dataListado.DataSource = LComprobante.MostrarComprobantes();
            this.OcultarColumnas();
            lbltotal.Text = "Cant Clientes Registradas: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void BuscarComprobante()
        {
            this.dataListado.DataSource = LComprobante.BuscarComprobante(this.txtbuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Cant Clientes Registradas: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarComprobante();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            Ventas form = Ventas.GetInstancia();
            string par1;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["ID"].Value);
            form.setComprobante(par1);
            this.Hide();

        }
    }
}
