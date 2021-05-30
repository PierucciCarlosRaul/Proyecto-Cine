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
    public partial class Registrar_Clientes : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        public Registrar_Clientes()
        {
            InitializeComponent();

            this.ttMensaje.SetToolTip(this.txtnombre, "Ingrese el Nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txtdni, "Ingrese el Documento");
            this.ttMensaje.SetToolTip(this.txtTelefono, "Ingrese el Telefono");
            this.ttMensaje.SetToolTip(this.txtEmail, "Ingrese  Correo Electronico");
            this.ttMensaje.SetToolTip(this.cmbBarrios, "Seleccione el Barrio");
            this.ttMensaje.SetToolTip(this.cmbCliente, "Seleccione el Tipo de Cliente");

            this.LlenarComboBarrio();
            this.LlenarComboCliente();
        }

        private void LlenarComboBarrio()
        {
            cmbBarrios.DataSource = LBarrio.Mostrar();
            cmbBarrios.ValueMember = "id_barrio";
            cmbBarrios.DisplayMember = "barrio";
        }
        private void LlenarComboCliente()
        {
            cmbCliente.DataSource = LTipocliente.Mostrar();
            cmbCliente.ValueMember = "id_tipos_cliente";
            cmbCliente.DisplayMember = "tipos_cliente";
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Limpiar()
        {
            this.txtnombre.Text = string.Empty;
            this.txtdni.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.cmbBarrios.Text = string.Empty;
            this.cmbCliente.Text = string.Empty;

            this.txtid.Text = string.Empty;

        }
       
        private void OcultarColumnas()
        {
            this.datalistado.Columns[0].Visible = false;
           // this.datalistado.Columns[7].Visible = false;
          
        }
        private void Mostrar()
        {
            this.datalistado.DataSource = LClientes.Mostrar();
            this.OcultarColumnas();
            total.Text = "Clientes Registrados: " + Convert.ToString(datalistado.Rows.Count);
        }
        private void BuscarNombre()
        {
            this.datalistado.DataSource = LClientes.BuscarNombre(this.txtbuscar.Text);
            this.OcultarColumnas();
            total.Text = "Clientes Registrados: " + Convert.ToString(datalistado.Rows.Count);
        }

        private void Registrar_Clientes_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();

            txtid.Enabled = false;
            txtnombre.Enabled = false;
            txtdni.Enabled = false;
            cmbBarrios.Enabled = false;
            cmbCliente.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;
            datalistado.Enabled = false;

            btnCliente.Enabled = false;
        
            btnEditar.Enabled = false;
            btnBorrarCliente.Enabled = true;


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            // this.IsEditar = false;
            txtid.Enabled = true;
            txtnombre.Enabled = true;
            txtdni.Enabled = true;
            cmbBarrios.Enabled = true;
            cmbCliente.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
            datalistado.Enabled = true;
            btnCliente.Enabled = true;
            btnEditar.Enabled = true;
            this.Limpiar();
           
            this.txtnombre.Focus();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
           // erroricono.SetError(txtTelefono, "Ingrese Telefono");
            try
            {
                string rpta = "";
                if (this.txtTelefono.Text == string.Empty || this.txtdni.Text == string.Empty || this.txtnombre.Text == string.Empty
                   || this.txtEmail.Text == string.Empty || this.cmbBarrios.Text == string.Empty || this.cmbCliente.ValueMember == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    erroricono.SetError(txtnombre, "Ingrese el nombre cliente");
                    erroricono.SetError(txtdni, "Ingrese Documento");
                    erroricono.SetError(txtTelefono, "Ingrese Telefono");
                    erroricono.SetError(txtEmail, "Ingrese Correo-Electronico");
                    erroricono.SetError(cmbCliente , "Ingrese Tipo de Cliente");
                    erroricono.SetError(cmbBarrios, "Ingrese Barrios");
                }
                if (this.IsNuevo)
                {
                    rpta = LClientes.Insertar(this.txtnombre.Text.Trim().ToUpper(),
                        this.txtdni.Text.Trim(),
                        Convert.ToInt32(this.cmbBarrios.SelectedValue),
                        Convert.ToInt32(this.cmbCliente.SelectedValue),
                        this.txtTelefono.Text,this.txtEmail.Text);

                }
                else
                {
                    rpta = LClientes.Editar(Convert.ToInt32(this.txtid.Text),
                        this.txtnombre.Text.Trim().ToUpper(),
                        this.txtdni.Text.Trim(), Convert.ToInt32(this.cmbBarrios.SelectedValue),
                        Convert.ToInt32(this.cmbCliente.SelectedValue),
                        this.txtTelefono.Text, this.txtEmail.Text);
                }

                if (rpta.Equals("OK"))
                {
                    if (this.IsNuevo)
                    {
                        this.MensajeOk("Se Insertó de forma correcta el registro");
                    }
                    else
                    {
                        this.MensajeOk("Se Actualizó de forma correcta el registro");
                    }
                }
                else
                {
                    this.MensajeError(rpta);
                }

                this.IsNuevo = false;
                this.IsEditar = false;
              
                this.Limpiar();
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtid.Text.Equals(""))
            {
                this.IsEditar = true;
              
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }

            btnCliente.Enabled = true;
            btnNuevo.Enabled = true;
            btnSiguiente.Enabled = true;
            btnVolver.Enabled = true;
            btnBorrarCliente.Enabled = true;

            txtnombre.Enabled = true;
            txtdni.Enabled = true;
            cmbBarrios.Enabled = true;
            cmbCliente.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
         
            this.Limpiar();
        
        }

        private void btnBorrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string id_cliente;
                    string Rpta = "";

                    foreach (DataGridViewRow row in datalistado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            id_cliente = Convert.ToString(row.Cells[1].Value);
                            Rpta = LClientes.Eliminar(Convert.ToInt32(id_cliente));

                           
                        }
                    }
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se Eliminó Correctamente el registro");
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ckbeliminar_CheckedChanged(object sender, EventArgs e)
        {

            if (ckbeliminar.Checked)
            {
                this.datalistado.Columns[0].Visible = true;
            }
            else
            {
                this.datalistado.Columns[0].Visible = false;
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void datalistado_DoubleClick(object sender, EventArgs e)
        {
            
            this.txtid.Text = Convert.ToString(this.datalistado.CurrentRow.Cells["id_cliente"].Value);
            this.txtnombre.Text = Convert.ToString(this.datalistado.CurrentRow.Cells["nombre"].Value);
            this.txtdni.Text = Convert.ToString(this.datalistado.CurrentRow.Cells["dni"].Value);
            this.cmbBarrios.SelectedValue = Convert.ToString(this.datalistado.CurrentRow.Cells["id_barrio"].Value);
            this.cmbCliente.SelectedValue = Convert.ToString(this.datalistado.CurrentRow.Cells["id_tipos_cliente"].Value);
            this.txtTelefono.Text = Convert.ToString(this.datalistado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.datalistado.CurrentRow.Cells["email"].Value);
            btnEditar.Enabled = true;
             MessageBox.Show("Para editar los datos presione en el boton Editar realize los cambios y luego precione en cargar cliente");
            //  this.tabControl1.SelectedIndex = 1;
            btnCliente.Enabled = false;
            btnNuevo.Enabled = false;
            btnSiguiente.Enabled = false;
            btnVolver.Enabled = false;
            btnBorrarCliente.Enabled = false;

            txtnombre.Enabled = false;
            txtdni.Enabled = false;
            cmbBarrios.Enabled = false;
            cmbCliente.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;

        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datalistado.Columns["eliminar"].Index)
            {
                DataGridViewCheckBoxCell ckbeliminar = (DataGridViewCheckBoxCell)datalistado.Rows[e.RowIndex].Cells["eliminar"];
                ckbeliminar.Value = !Convert.ToBoolean(ckbeliminar.Value);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
