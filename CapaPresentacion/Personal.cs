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
    public partial class Personal : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;
        public Personal()
        {
            InitializeComponent();


            this.ttMensajes.SetToolTip(this.txtnombre, "Ingrese el Nombre del personal");
            this.ttMensajes.SetToolTip(this.txtdni, "Ingrese el Nro de Documento");
            this.ttMensajes.SetToolTip(this.dtpnacimiento, "Ingrese la fecha de nacimiento");
            this.ttMensajes.SetToolTip(this.cmbsexo, "Ingrese el sexo del personal a registrar");
            this.ttMensajes.SetToolTip(this.txtemail, "ingrese la direccion de correo electronico");
            this.ttMensajes.SetToolTip(this.txttel, "Ingrese el nro de telefono");
            this.ttMensajes.SetToolTip(this.txtacceso, "Indique el tipo de acceso al sistema");
            this.ttMensajes.SetToolTip(this.txtusuario, "Indique el usuario con el que ingresara al sistema");
            this.ttMensajes.SetToolTip(this.txtpass, "ingrese el password con el que ingresara al sistema");

            this.LlenarComboSexo();
            
        }

        private void LlenarComboSexo()
        {
            cmbsexo.DataSource = LSexo.MostrarSexo();
            cmbsexo.ValueMember = "id_sexo";
            cmbsexo.DisplayMember = "sexo";
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
            this.txtid.Text = string.Empty;
            this.txtnombre.Text = string.Empty;
            this.txtdni.Text = string.Empty;
            this.dtpnacimiento.Text = string.Empty;
            this.cmbsexo.Text = string.Empty;
            this.txtdomi.Text = string.Empty;
            this.txtemail.Text = string.Empty;
            this.txttel.Text = string.Empty;
            this.txtacceso.Text = string.Empty;
            this.txtusuario.Text = string.Empty;
            this.txtpass.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {

            this.txtid.ReadOnly = !valor;
            this.txtnombre.ReadOnly = !valor;
            this.txtdni.ReadOnly = !valor;
            this.dtpnacimiento.Enabled = valor;
            this.cmbsexo.Enabled = valor;
            this.txtdomi.ReadOnly = !valor;
            this.txtemail.ReadOnly = !valor;
            this.txttel.ReadOnly = !valor;
            this.txtacceso.ReadOnly = !valor;
            this.txtusuario.ReadOnly = !valor;
            this.txtpass.ReadOnly = !valor;

        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = (false);
                this.btnGuardar.Enabled = (true);
                this.btnEditar.Enabled = (false);
                this.btnCancelar.Enabled = (true);

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = (true);
                this.btnGuardar.Enabled = (false);
                this.btnEditar.Enabled = (true);
                this.btnCancelar.Enabled = (false);
            }

        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            // this.dataListado.Columns[1].Visible = false;
            // this.datalistado.Columns[7].Visible = false;

        }

        private void MostrarPersonal()
        {
            this.dataListado.DataSource = Lpersonal.Mostrarpersonal();
            this.OcultarColumnas();
            lbltotal.Text = "Cant Personas Registradas: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarPersonal()
        {
            this.dataListado.DataSource = Lpersonal.BuscarPersonal(this.txtbuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Cant Personas Registradas: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Personal_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.MostrarPersonal();

            this.Habilitar(false);
            this.Botones();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarPersonal();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            txtnombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String rpta = "";
                if (this.txtnombre.Text == string.Empty)
                {
                    MensajeError("Faltan ingresar datos, seran marcados");
                    Erroricono.SetError(txtnombre, "Ingrese el nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = Lpersonal.InsertarPersonal(this.txtnombre.Text.Trim().ToUpper(),
                            this.txtdni.Text,
                            Convert.ToInt32(this.cmbsexo.SelectedValue),
                            dtpnacimiento.Value,
                            this.txtdomi.Text,
                            this.txtemail.Text,
                            this.txttel.Text,
                            this.txtacceso.Text,
                            this.txtusuario.Text,
                            this.txtpass.Text);
                    }
                    else
                    {
                        rpta = Lpersonal.EditarPersonal(Convert.ToInt32(this.txtid.Text),this.txtnombre.Text.Trim().ToUpper(),
                            this.txtdni.Text,
                            Convert.ToInt32(this.cmbsexo.SelectedValue),
                            dtpnacimiento.Value,
                            this.txtdomi.Text,
                            this.txtemail.Text,
                            this.txttel.Text,
                            this.txtacceso.Text,
                            this.txtusuario.Text,
                            this.txtpass.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Registro de manera correcta");
                        }
                        else
                        {

                            this.MensajeOk("Los datos se Actualizaron con exito");
                        }
                    }
                    else
                    {

                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.MostrarPersonal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtid.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void chkeliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkeliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string id_personal;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            id_personal = Convert.ToString(row.Cells[1].Value);
                            Rpta = Lpersonal.EliminarPersonal(Convert.ToInt32(id_personal));


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
                    this.MostrarPersonal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["eliminar"].Index)
            {
                DataGridViewCheckBoxCell ckbeliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["eliminar"];
                ckbeliminar.Value = !Convert.ToBoolean(ckbeliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtid.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_personal"].Value);
            this.txtnombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtdni.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["dni"].Value);
            this.dtpnacimiento.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_nac"].Value);
            this.cmbsexo.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_sexo"].Value).ToString();
            this.txtdomi.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["domicilio"].Value);
            this.txtemail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.txttel.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtacceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["acceso"].Value);
            this.txtusuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
            this.txtpass.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["password"].Value);

            this.tabControl1.SelectedIndex = 1;
        }
    }
    }

