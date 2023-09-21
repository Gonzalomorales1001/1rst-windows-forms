using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_Parcial_2
{
    public partial class Parcial2 : Form
    {
        public Parcial2()
        {
            InitializeComponent();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Parcial2_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void calc_Click(object sender, EventArgs e)
        {
            mostrarValores();
        }

        public void mostrarValores()
        {
            //creo una instancia de mi clase evento
            Evento recital = new Evento();
            //valido que los campos sean correctos (que no esten vacíos y que sean números)
            //para eso, utilizo una funcion que retorna un valor booleano para asignarle a mi variable bandera
            bool textboxsValidosBandera = validarTextBoxs();
            //si son validos, ejecuto el then del if, y si no, muestro un mensaje con el metodo show
            if (textboxsValidosBandera)
            {
                recital.estadioM2 = Convert.ToDouble(ingresoCapacidadEstadio.Text);
                recital.capacidadTribuna = Convert.ToInt32(ingresoCapacidadTribuna.Text);
                recital.escenarioPorcentaje = Convert.ToDouble(ingresoPorcentajeEscenario.Text);
                recital.ticketPrecio = Convert.ToDouble(ingresoPrecioTicket.Text);
                recital.ticketPrecioVIP = Convert.ToDouble(ingresoPrecioTicketVIP.Text);
                //el retorno del metodo es la cantidad de entradas
                muestraEntradas.Text = Convert.ToString(recital.calcularEntradas());
                //el retorno del metodo es un vector que tiene los ingresos si se vendieran todas las entradas
                double[] ingresos = recital.calcularIngresos(recital.calcularEntradas());
                IngresosTicket.Text = "$" + Convert.ToString(ingresos[0]);
                IngresosTicketVIP.Text = "$" + Convert.ToString(ingresos[1]);
                IngresosTotales.Text = "$" + Convert.ToString(ingresos[2]);
            }
            else
            {
                //el mensaje que se muestra si es que los campos no son validos
                MessageBox.Show("Los datos ingresados no son válidos","Error al calcular",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public bool validarTextBoxs()
        {
            bool bandera=true;
            //creo un vector que tiene como valor un objeto el cual es instancia de la clase TextBox
            TextBox[] misTextBoxs = new TextBox[5];
            //guardo manualmente mis textboxs en este vector
            misTextBoxs[0] = ingresoCapacidadEstadio;
            misTextBoxs[1] = ingresoCapacidadTribuna;
            misTextBoxs[2] = ingresoPorcentajeEscenario;
            misTextBoxs[3] = ingresoPrecioTicket;
            misTextBoxs[4] = ingresoPrecioTicketVIP;
            for(int i = 0; i < misTextBoxs.Length; i++)
            {
                //verifico si en cada posicion la longitud de su propiedad .Text es 0 (pa saber si ta vacio) o NO es un double
                if (misTextBoxs[i].Text.Length == 0 || !double.TryParse(misTextBoxs[i].Text, out double resultado) || Convert.ToInt32(misTextBoxs[i].Text) < 0)
                {
                    //si es cierto, mi bandera es false, entonces va a interpretar que lo campos no son validos
                    bandera = false;
                }
            }
            return bandera;
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
    class Evento
    {
        public double estadioM2;
        public int capacidadTribuna;
        public double escenarioPorcentaje;
        public double ticketPrecio;
        public double ticketPrecioVIP;
        public int calcularEntradas()
        {
            //calculo la cantidad de entradas y retorno el valor para mostrarlo en la propiedad .text asi lo vea el usuario
            double tribunaM2 = estadioM2 * 0.2;
            double escenarioM2 = (escenarioPorcentaje * estadioM2) / 100;
            double espacioM2 = estadioM2 - tribunaM2 - escenarioM2;

            int capacidad = Convert.ToInt32(espacioM2 * 4);
            int capacidadTotal = capacidadTribuna + capacidad;
            return capacidadTotal;
        }
        public double[] calcularIngresos(int cantidadEntradas)
        {
            int entradasVIP = Convert.ToInt32(cantidadEntradas * 0.3);
            int entradasNoVIP = cantidadEntradas - entradasVIP;
            double gananciasVIP = ticketPrecioVIP * entradasVIP;
            double gananciasNoVIP = ticketPrecio * entradasNoVIP;
            double gananciasTotales = gananciasVIP + gananciasNoVIP;
            double[] ganancias = new double[3];
            ganancias[0] = gananciasNoVIP;
            ganancias[1] = gananciasVIP;
            ganancias[2] = gananciasTotales;
            return ganancias;
        }
        
    }
}
