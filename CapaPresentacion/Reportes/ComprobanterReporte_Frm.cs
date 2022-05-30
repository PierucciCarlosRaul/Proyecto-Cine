using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class ComprobanterReporte_Frm : Form
    {
        private int _idComprobante;

        public int idComprobante
        {
            get  { return _idComprobante; }
            set { _idComprobante = value; }
        }
    public ComprobanterReporte_Frm()
        {
            InitializeComponent();
        }

        private void Comprobante_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.Reporte_Factura' Puede moverla o quitarla según sea necesario.
            try
            {
                this.Reporte_FacturaTableAdapter.Fill(this.dsPrincipal.Reporte_Factura, idComprobante);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
                throw;
            }
           
        }
    }
}
