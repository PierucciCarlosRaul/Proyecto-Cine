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
    public partial class Ventas : Form{
        private bool IsNuevo;
        private DataTable dtDetalle;
        private static Ventas _instancia;

        public static Ventas GetInstancia()
        {

            if (_instancia == null)
            {
                _instancia = new Ventas();
            }
            return _instancia;
        }
        public int id_trabajador;
        int ce;
        double totalMonto, totadu, totmeno, totmayo, recaudacion, menores, adultos,res,
        n1, n2, n3, sumaentrada, acuentrada, mayores, adu, meno, mayo, f, Au, aumento;

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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
           
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            txtidcomprobante.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
          
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string id_comprobante;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            id_comprobante = Convert.ToString(row.Cells[1].Value);
                            Rpta = LComprobante.EliminarComprobante(Convert.ToInt32(id_comprobante));
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
                    this.MostrarComprobante();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnbuscarcomprobante_Click(object sender, EventArgs e)
        {
            VistaComprobante cc= new VistaComprobante();
            cc.ShowDialog();
        }

        private void btnBuscarcliente_Click(object sender, EventArgs e)
        {
            VistaCliente cv = new VistaCliente();
            cv.ShowDialog();
        }

        

        public void setCliente(string id_cliente, string nombre) {
            this.txtidcliente.Text = id_cliente;
            this.txtcliente.Text = nombre;
        
        }

        public void setComprobante(string comprobante)
        {
            this.txtidecomprobante.Text = comprobante;
        }


        public Ventas()
        {
            InitializeComponent();
            
            this.ttMensajes.SetToolTip(this.txtidcomprobante, "Ingrese el Numero de comprobante");
            this.ttMensajes.SetToolTip(this.txtidcliente, "Busque e ingrese el codigo del cliente ");
            this.ttMensajes.SetToolTip(this.dtpfecha, "Ingrese la fecha de compra");
            this.ttMensajes.SetToolTip(this.txtcliente, "Busque e ingrese los datos del cliente");
            this.ttMensajes.SetToolTip(this.btnBuscarcliente, "Precione para obtener los datos cliente");
            this.ttMensajes.SetToolTip(this.cmbPelicula, "Indique la pelicula seleccionada por el cliente");
            this.ttMensajes.SetToolTip(this.cmbNroSala, "Indique el numero de sala para el cliente");
            this.ttMensajes.SetToolTip(this.cmbTisala, "Indique el tipo de sala ");
            
            this.ttMensajes.SetToolTip(this.cmbPago, "Indique la forma de pago del cliente");
            this.ttMensajes.SetToolTip(this.cmbCompra, "Indique la forma de compra de su cliente");
            this.ttMensajes.SetToolTip(this.cmbNroButaca, "Indique el/los numeros de butacas a ocupar por el cliente");
            this.ttMensajes.SetToolTip(this.cmbFuncion, "seleccione la funcion a la que asistira el cliente");
            this.ttMensajes.SetToolTip(this.txtidecomprobante, "Seleccione el comprobante que pertenece a la compra que quiere realizar");
            this.ttMensajes.SetToolTip(this.btnbuscarcomprobante, "Precione para obtener los datos del comprobante");


         /*   this.txtidcliente.Visible = false;
            this.txtcliente.ReadOnly = true;
            this.txtidecomprobante.ReadOnly = false;*/

            this.LlenarComboFuncion();
            this.LlenarComboButaca();
            this.LlenarComboTipoCompra();
            this.LlenarComboPelicula();
            this.LlenarComboFormaPago();
            this.LlenarComboNroSalas();
            this.LlenarComboTipoSalas();
        }

        private void LlenarComboTipoSalas()
        {
            cmbTisala.DataSource = LtipoSala.MostrarTipoSala();
            cmbTisala.ValueMember = "id_tipo_sala";
            cmbTisala.DisplayMember = "tipo_sala";
        }

        private void LlenarComboNroSalas()
        {
            cmbNroSala.DataSource = LcomboSala.MostrarComboSala();
            cmbNroSala.ValueMember = "id_sala";
            cmbNroSala.DisplayMember = "nro_sala";
        }

        private void LlenarComboFormaPago()
        {
            cmbPago.DataSource = LcomboPago.MostrarComboPago(); 
            cmbPago.ValueMember = "id_forma_pago";
            cmbPago.DisplayMember = "forma_pago";
        }
        private void LlenarComboPelicula()
        {
            cmbPelicula.DataSource = LcomboPelicula.MostrarComboPelicula();
            cmbPelicula.ValueMember = "id_pelicula";
            cmbPelicula.DisplayMember = "nombre";
        }


        private void LlenarComboTipoCompra()
        {
            cmbCompra.DataSource = LTipo_Compra.MostrarTipo_Compra();
            cmbCompra.ValueMember = "id_tipo_compra";
            cmbCompra.DisplayMember = "tipo_compra";
        }

        private void LlenarComboButaca()
        {
            cmbNroButaca.DataSource = LButaca.MostrarButacas();
            cmbNroButaca.ValueMember = "id_butaca";
            cmbNroButaca.DisplayMember = "nro_butaca";
        }


        private void LlenarComboFuncion()
        {
            cmbFuncion.DataSource = LFuncion.MostrarFuncion();
            cmbFuncion.ValueMember = "id_funcion";
            cmbFuncion.DisplayMember = "fecha y hora";
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
            this.txtidcomprobante.Text = string.Empty;
            this.txtidcliente.Text = string.Empty;
            this.dtpfecha.Text = string.Empty;
            this.txtcliente.Text = string.Empty;
            this.cmbPelicula.Text = string.Empty;
            this.cmbNroSala.Text = string.Empty;
            this.cmbTisala.Text = string.Empty;
            this.cmbPago.Text = string.Empty;
            this.cmbCompra.Text = string.Empty;

            this.cmbNroButaca.Text = string.Empty;
            this.cmbFuncion.Text = string.Empty;
            this.txtidecomprobante.Text = string.Empty;
          }

        private void Habilitar(bool valor)
        {
            // TEXT BOX
            this.txtidcomprobante.ReadOnly = !valor;
            this.txtidcliente.ReadOnly = !valor;
            this.txtcliente.ReadOnly = !valor;
            this.txtidecomprobante.ReadOnly = !valor;
            // Combo Box
            this.cmbPelicula.Enabled = valor;
            this.cmbNroSala.Enabled = valor; 
            this.cmbTisala.Enabled = valor;
            this.cmbPago.Enabled = valor;
            this.cmbCompra.Enabled = valor;
            this.cmbNroButaca.Enabled = valor;
            this.cmbFuncion.Enabled = valor;
            //DATETIMEPICKET
            this.dtpfecha.Enabled = valor;
            //BOTONES
            this.btnBuscarcliente.Enabled = valor;
            this.btnbuscarcomprobante.Enabled = valor;
        }

        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = (false);
                this.btnGuardar.Enabled = (true);
                
                this.btnCancelar.Enabled = (true);

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = (true);
                this.btnGuardar.Enabled = (false);
                
                this.btnCancelar.Enabled = (false);
            }

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
            lbltotal.Text = "Cant Ventas Registradas: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void BuscarComprobante()
        {
            this.dataListado.DataSource = LComprobante.BuscarComprobante(this.txtbuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Cant Ventas Registradas: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.MostrarComprobante();

            this.Habilitar(false);
            this.Botones();
        }
        public void Sumar(TextBox uno, TextBox dos, TextBox tres, TextBox respu)
        {
            n1 = int.Parse(uno.Text);
            n2 = int.Parse(dos.Text);
            n3 = int.Parse(tres.Text);
            res = n1 + n2 + n3;
            respu.Text = res.ToString();
        }
        private void Ventas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private bool validar()
        {
            if (string.IsNullOrEmpty(txtAum.Text))
            {
                MessageBox.Show("Sino Existe aumento ingrese Valor 0...");
                txtAum.Focus();
                txtAum.BackColor = Color.Yellow;
                return false;
            }
          
            if (cmbPelicula.Text == "")
            {
                MessageBox.Show("seleccione la PELICULA..");
                cmbPelicula.Focus();
                cmbPelicula.BackColor = Color.Yellow;
                return false;
            }
            if (cmbNroSala.Text == "")
            {
                MessageBox.Show("seleccione la SALA..");
                cmbNroSala.Focus();
                cmbNroSala.BackColor = Color.Yellow;
                return false;
            }
            if (cmbTisala.Text == "")
            {
                MessageBox.Show("seleccione el Formato de la pelicula..");
                cmbTisala.Focus();
                cmbTisala.BackColor = Color.Yellow;
                return false;
            }
            if (cmbNroButaca.Text == "")
            {
                MessageBox.Show("seleccione el nro de BUTACA..");
                cmbNroButaca.Focus();
                cmbNroButaca.BackColor = Color.Yellow;
                return false;
            }

            if (cmbFuncion.Text == "")
            {
                MessageBox.Show("Seleccion la funcion de la pelicula..");
                cmbFuncion.Focus();
                cmbFuncion.BackColor = Color.Yellow;
                return false;
            }
            if (cmbPago.Text == "")
            {
                MessageBox.Show("Falto indicar cual es la forma de pago..");
                cmbPago.Focus();
                cmbPago.BackColor = Color.Yellow;
                return false;
            }
            if (dtpfecha.Value < DateTime.Today)
            {
                MessageBox.Show("La fecha ingresada es INCORRECTA..");
                cmbPago.Focus();
                cmbPago.BackColor = Color.Yellow;
                return false;
            }
            if (cmbCompra.Text == "")
            {
                MessageBox.Show("Falto indicar cual es el TIPO DE COMPRA...");
                cmbCompra.Focus();
                cmbCompra.BackColor = Color.Yellow;
                return false;
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("Ingrese la Cantidad de Adultos de lo contrario ingrese Valor 0...");
                textBox5.Focus();
                textBox5.BackColor = Color.Yellow;
                return false;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Ingrese la Cantidad de Menores de lo contrario ingrese Valor 0...");
                textBox4.Focus();
                textBox4.BackColor = Color.Yellow;
                return false;
            }
            if (txtcantMay.Text == "")
            {
                MessageBox.Show("Ingrese la Cantidad de Mayores de lo contrario ingrese Valor 0...");
                txtcantMay.Focus();
                txtcantMay.BackColor = Color.Yellow;
                return false;
            }
            return true;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
           // if (validar())
            {
            /*  LDetalle_Comprobante Cs = new LDetalle_Comprobante();
                Cs.= dtpfecha.Value;
                //Cs.pDia = cmbDia.SelectedIndex + 1;
                Cs.pFormadepago = cmbPago.SelectedIndex + 1;
                Cs.pTipodecompra = cmbCompra.SelectedIndex + 1;
                //Cs.pDia = cmbDia.SelectedIndex + 1;
                Cs.pTsala = cmbTisala.SelectedIndex + 1;
                Cs.pMonto = Cs.calcularmonto();
                //Cs.pCliente = cmbcliente.SelectedIndex + 1;*/

                Au = Convert.ToDouble(txtAum.Text);
                aumento = LDetalle_Comprobante.calcularmonto() + ((LDetalle_Comprobante.calcularmonto() * Au) / 100);
                label54.Text = aumento.ToString();//el precio de la entrada general

                Sumar(textBox5, textBox4, txtcantMay, textBox6);

                n1 = Convert.ToDouble(textBox5.Text);
                n2 = Convert.ToDouble(textBox4.Text);
                n3 = Convert.ToDouble(txtcantMay.Text);
                totadu = aumento * n1;
                totmeno = ((aumento - (aumento * 0.20)) * n2);
                totmayo = ((aumento - (aumento * 0.20)) * n3);

                totmaymen.Text = (aumento - (aumento * 0.20)).ToString();

                f = (totadu + totmeno + totmayo);
                txtsin.Text = Math.Round((f), 2).ToString();

                sumaentrada = (n1 + n2 + n3);//suma total de entradas por venta
                ce++;//contador total de entradas por cada click
                label24.Text = ce.ToString();//muestro el contador
                label26.Text = sumaentrada.ToString();//muestro la suma de las entradas
                label19.Text = totadu.ToString();//muestro la cantidad de entradas por adultos por venta compradas
                label20.Text = totmeno.ToString();//muestro la cantidad de menores por entrada 
                label21.Text = totmayo.ToString();//muestro la cantidad de mayores por entrada 
                totalMonto = totadu + totmeno + totmayo;//suma de entradas total por publico

                //    Int32 hora = DateTime.Now.Hour;

               // lblxxx.Text = totalMonto.ToString();



                float descuento = 0;

                if (dtpfecha.Value.DayOfWeek != DayOfWeek.Saturday &&
                  dtpfecha.Value.DayOfWeek != DayOfWeek.Sunday &&
                  dtpfecha.Value.DayOfWeek != DayOfWeek.Friday)
                {
                    descuento += 0.05F;
                }
             /*   if (Cs.pFormadepago == 2)
                {
                    descuento += 0.05F;
                }
                if (Cs.pTipodecompra == 1)
                    descuento += 0.05F;

                if (Cs.pTsala == 1)
                    descuento += 0.05F;*/


                totalMonto = totalMonto * (1 - descuento);

                txttotalventa.Text = Math.Round((totalMonto), 2).ToString();//muestro el total de la entradas vendidas en 1 venta
                recaudacion += totalMonto;
                txtrecaudacion.Text = Math.Round((recaudacion), 2).ToString();//muestro lo que se vende acumulo las ventas las sumo

                totadu = totadu * (1 - descuento);
                label19.Text = Math.Round((totadu), 2).ToString();//muestro la cantidad de entradas por adultos por venta compradas
                adultos += totadu;//acumulo adultos
                label28.Text = Math.Round((adultos), 2).ToString();


                totmeno = totmeno * (1 - descuento);
                label20.Text = Math.Round((totmeno), 2).ToString();//muestro la cantidad de menores por entrada 
                menores += totmeno;
                label42.Text = Math.Round((menores), 2).ToString();

                totmayo = totmayo * (1 - descuento);
                label21.Text = Math.Round((totmayo), 2).ToString();//muestro la cantidad de mayores por entrada 
                mayores += totmayo;//acumulo adultos
                label38.Text = Math.Round((mayores), 2).ToString();

                acuentrada += sumaentrada;
                lbltotentradas.Text = Math.Round((acuentrada), 2).ToString();
                adu += n1;
                meno += n2;
                mayo += n3;
                label37.Text = Math.Round((adu), 2).ToString();
                label33.Text = Math.Round((meno), 2).ToString();
                label32.Text = Math.Round((mayo), 2).ToString();

                txtDes.Text = descuento.ToString();
            }
        }
    }
}
