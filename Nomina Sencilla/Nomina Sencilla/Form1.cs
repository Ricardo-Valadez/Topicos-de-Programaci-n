using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina_Sencilla
{
    public partial class Form1 : Form
    {
        //Creacion del timer
        Timer t = new Timer();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            //Intervalos de tiempo
            //Milisegundos
            t.Interval = 1000;

            t.Tick += new EventHandler(this.t_Tick);

            //Comieza cuando se crea el forms
            t.Start();
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }
        //Evento de timer
        private void t_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;

            //Tiempo
            string time = "";

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += "";

            //Actualizacion
            lblHora.Text = time;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dddd MMMM:yy");
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            double Salario;

            double x = Convert.ToDouble(txtSalario.Text);
            double y = Convert.ToDouble(txtHoras.Text);

            Salario = x * y;
            if (Salario>=141.7)
            {
                MessageBox.Show("Datos del empleado:\nNombre: " + txtNombre.Text + "\nSalario: $" + Salario, "Datos del Empleado", MessageBoxButtons.OK);

            }
            else
                MessageBox.Show("Datos del empleado:\nNombre: " + txtNombre.Text, "Datos del Empleado", MessageBoxButtons.OK);

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }
    }
}
