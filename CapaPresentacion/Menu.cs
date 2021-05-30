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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Registrar_Clientes formulario = new Registrar_Clientes();
            formulario.Show();
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
