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
    public partial class ListadoDetalles : Form
    {
        public ListadoDetalles()
        {
            InitializeComponent();
        }

        private void ListadoDetalles_Load(object sender, EventArgs e)
        {
            this.MostrarDetalle_Comprobante();
        }


        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            // this.dataListado.Columns[1].Visible = false;
            // this.datalistado.Columns[7].Visible = false;

        }
        private void BuscarDetalleComprobante()
        {
            this.dataListado.DataSource = LDetalle_Comprobante.BuscarDetalleComprobante(this.txtbuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Cant Ventas Registradas " + Convert.ToString(dataListado.Rows.Count);
        }


        private void MostrarDetalle_Comprobante()
        {
            this.dataListado.DataSource = LDetalle_Comprobante.MostrarDetalle_Comprobante();
            this.OcultarColumnas();
            lbltotal.Text = "Cant Ventas Registradas: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarDetalleComprobante();
        }
    }
}
