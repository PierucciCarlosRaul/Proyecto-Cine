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
    public partial class Principal : Form
    {
        private int childFormNumber = 0;
        public string id_personal = "";
        public string nombre = "";
        public string acceso = "";
        
        public Principal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cargarPeliculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Peliculas frm = new Peliculas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void realizarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_Clientes frm = new Registrar_Clientes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personal frm = new Personal();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            GestionUsiario();
        }

        private void GestionUsiario() {
            if (acceso == "Administrador")
            {
                this.productos.Enabled = true;
                this.ventas.Enabled = true;
                this.consultas.Enabled = true;
                this.adminpersonal.Enabled = true;
            }
            else if (acceso == "Vendedor")
            {
                this.productos.Enabled = false;
                this.ventas.Enabled = true;
                this.consultas.Enabled = false;
                this.adminpersonal.Enabled = false;
            }
            else {
                this.sistema.Enabled = true;
                this.herramientas.Enabled = false;
                this.ventanas.Enabled = false;
                this.ayuda.Enabled = false;
                this.ver.Enabled = false;
                this.productos.Enabled = false;
                this.ventas.Enabled = false;
                this.consultas.Enabled = false;
                this.adminpersonal.Enabled = false;
            }
        }

        private void comprobanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas frm = Ventas.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.id_trabajador = Convert.ToInt32(this.id_personal);

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_Clientes frm = new Registrar_Clientes();
            frm.Show();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
