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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            // lblhora.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

           
          
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            /* string Usuario = "cinemax";
             string Contraseña = "2019";
             if (txtusuario.Text == Usuario && txtpass.Text == Contraseña)
             {
                 Menu formulario = new Menu();
                 formulario.Show();

             }
             else
             {
                 MessageBox.Show("   Los datos ingresados no son correctos  ");
             }*/


            DataTable Datos = CapaLogica.Lpersonal.Login(this.txtusuario.Text, this.txtpass.Text);
            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("No existe el usuario No tiene acceso al sistema", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {

                Principal frm = new Principal();
                frm.id_personal = Datos.Rows[0][0].ToString();
                frm.nombre = Datos.Rows[0][1].ToString();
                frm.acceso = Datos.Rows[0][2].ToString();

                frm.Show();
                this.Hide();

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // lblhora.Text = DateTime.Now.ToString();
        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }
    }
}
