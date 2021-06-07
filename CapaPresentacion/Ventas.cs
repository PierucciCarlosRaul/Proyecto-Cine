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
    public partial class Ventas : Form
    {
        int ce;
        double totalMonto, totadu, totmeno, totmayo, recaudacion, menores, adultos,res,
        n1, n2, n3, sumaentrada, acuentrada, mayores, adu, meno, mayo, f, Au, aumento;
        private static Ventas _instancia;

        public static Ventas GetInstancia() {

            if (_instancia == null)
            {
                _instancia = new Ventas();
            }
            return _instancia;
        }

        public void setCliente(string id_cliente, string nombre) {
            this.txtidcliente.Text = id_cliente;
            this.txtcliente.Text = nombre;
        
        }

        public void setComprobante(string id_comprobante)
        {
            this.txtidcliente.Text = id_comprobante;
        }


        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {

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
