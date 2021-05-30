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
    public partial class Peliculas : Form {
        private bool IsNuevo = false;

        private bool IsEditar = false;
        
        public Peliculas()
        {
            InitializeComponent();

            this.ttMensajes.SetToolTip(this.txtnombre, "Ingrese el Nombre de la pelicula a registrar");
            this.ttMensajes.SetToolTip(this.txtargumento, "Ingrese una breve descripcion");
            this.ttMensajes.SetToolTip(this.dtmestreno, "Ingrese la fecha a estrenar");
            this.ttMensajes.SetToolTip(this.txtduracion, "Ingrese el tiempo de duracion de la pelicula");
            this.ttMensajes.SetToolTip(this.cmbidioma, "Seleccione el idioma de la pelicula");
            this.ttMensajes.SetToolTip(this.cmbclasi, "Indique para que publico es apta su pelicula");
            this.ttMensajes.SetToolTip(this.cmbcali, "Seleccione una calificacion");
            this.ttMensajes.SetToolTip(this.cmbgene, "Indique el genero de la pelicula");

            this.LlenarComboIdioma();
            this.LlenarComboClasificacion();
            this.LlenarComboCalificacion();
            this.LlenarComboGenero();
        }

        private void LlenarComboIdioma()
        {
            cmbidioma.DataSource = Lidioma.MostrarIdioma();
            cmbidioma.ValueMember = "id_idioma";
            cmbidioma.DisplayMember = "idioma";
        }
        private void LlenarComboClasificacion()
        {
            cmbclasi.DataSource = Lclasificacion.MostrarClasificaciones();
            cmbclasi.ValueMember = "id_clasificacion";
            cmbclasi.DisplayMember = "clasificacion";
        }
        private void LlenarComboCalificacion()
        {
            cmbcali.DataSource = Lcalificacion.MostrarCalificaciones();
            cmbcali.ValueMember = "id_calificacion";
            cmbcali.DisplayMember = "calificacion";
        }
        private void LlenarComboGenero()
        {
            cmbgene.DataSource = Lgenero.MostrarGenero();
            cmbgene.ValueMember = "id_genero";
            cmbgene.DisplayMember = "genero";
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
            this.txtargumento.Text = string.Empty;
            this.txtduracion.Text = string.Empty;
            this.dtmestreno.Text = string.Empty;
            this.cmbidioma.Text = string.Empty;
            this.cmbclasi.Text = string.Empty;
            this.cmbcali.Text = string.Empty;
            this.cmbgene.Text = string.Empty;

        //    this.txtidpelicula.Text = string.Empty;

        }

        private void Habilitar(bool valor) {

            this.txtnombre.ReadOnly = !valor;
            this.txtargumento.ReadOnly = !valor;
            this.txtduracion.ReadOnly = !valor;
            this.dtmestreno.Enabled = valor;
            this.cmbidioma.Enabled = valor;
            this.cmbclasi.Enabled = valor;
            this.cmbcali.Enabled = valor;
            this.cmbgene.Enabled = valor;
        
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
            else {
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
        private void MostrarPelicula()
        {
            this.dataListado.DataSource = LPelicula.MostrarPelicula();
            this.OcultarColumnas();
            lbltotal.Text = "Cant Peliculas Registradas: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void BuscarPelicula()
        {
            this.dataListado.DataSource = LPelicula.BuscarPelicula(this.txtbuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Cant Peliculas Registradas: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void Peliculas_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.MostrarPelicula();

            this.Habilitar(false);
            this.Botones();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarPelicula();
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
        { try { String rpta = "";
                if (this.txtnombre.Text == string.Empty)
                {
                    MensajeError("Faltan ingresar datos, seran marcados");
                    Erroricono.SetError(txtnombre, "Ingrese el nombre");
                }
                else {
                    if (this.IsNuevo)
                    {
                        rpta = LPelicula.InsertarPelicula(this.txtnombre.Text.Trim().ToUpper(),
                            this.txtargumento.Text,
                            dtmestreno.Value,
                            Convert.ToInt32(this.txtduracion.Text),
                            Convert.ToInt32(this.cmbidioma.SelectedValue),
                            Convert.ToInt32(this.cmbclasi.SelectedValue),
                            Convert.ToInt32(this.cmbcali.SelectedValue),
                            Convert.ToInt32(this.cmbgene.SelectedValue));
                    }
                    else { 
                    rpta = LPelicula.EditarPelicula(Convert.ToInt32(this.txtid.Text),this.txtnombre.Text.Trim().ToUpper(),
                            this.txtargumento.Text.ToString(),
                            dtmestreno.Value,
                            Convert.ToInt32(this.txtduracion.Text),
                            Convert.ToInt32(this.cmbidioma.SelectedValue),
                            Convert.ToInt32(this.cmbclasi.SelectedValue),
                            Convert.ToInt32(this.cmbcali.SelectedValue),
                            Convert.ToInt32(this.cmbgene.SelectedValue));
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
                    else {

                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.MostrarPelicula();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message + ex.StackTrace);
            } 
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtid.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_pelicula"].Value);
            this.txtnombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtargumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["argumento"].Value);
            this.dtmestreno.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["estreno"].Value);
            this.txtduracion.Text = Convert.ToInt32(this.dataListado.CurrentRow.Cells["duracion"].Value).ToString();
           // this.txtduracion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["duracion"].Value);
            this.cmbidioma.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_idioma"].Value);
            this.cmbclasi.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_clasificacion"].Value);
            this.cmbcali.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_calificacion"].Value);
            this.cmbgene.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_genero"].Value);

           this.tabControl1.SelectedIndex = 1;

           /* btnEditar.Enabled = true;
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
            txtEmail.Enabled = false;*/
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

         /*   btnCliente.Enabled = true;
            btnNuevo.Enabled = true;
            btnSiguiente.Enabled = true;
            btnVolver.Enabled = true;
            btnBorrarCliente.Enabled = true;

            txtnombre.Enabled = true;
            txtdni.Enabled = true;
            cmbBarrios.Enabled = true;
            cmbCliente.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;*/
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["eliminar"].Index)
            {
                DataGridViewCheckBoxCell ckbeliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["eliminar"];
                ckbeliminar.Value = !Convert.ToBoolean(ckbeliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {try{DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string id_pelicula;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            id_pelicula = Convert.ToString(row.Cells[1].Value);
                            Rpta = LPelicula.EliminarPelicula(Convert.ToInt32(id_pelicula));


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
                    this.MostrarPelicula();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
