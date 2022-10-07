using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoSemaforo
{
    public partial class Semaforo : Form
    {
        public Semaforo()
        {
            InitializeComponent();
        }

        int caso = 0;

        private void TrabajoSemaforo_Load(object sender, EventArgs e)
        {
            //Aqui elige la imagen que ocupamos
            ptbImagen.Image = TrabajoSemaforo.Properties.Resources.Apagado;
            ptbImagen2.Image = TrabajoSemaforo.Properties.Resources.Apagado;

            //Botones que no se necesiten estan desabilitados

            btnApagar.Enabled = false;
            btnDetener.Enabled = false;
        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            timer1.Start();

            btnApagar.Enabled = true;
            btnDetener.Enabled = true;
            btnEncender.Enabled = false;

            label1.Text = "Encendido";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (caso)
            {
                case 0:

                    ptbImagen.Image = TrabajoSemaforo.Properties.Resources.Verde;
                    ptbImagen2.Image = TrabajoSemaforo.Properties.Resources.Rojo;

                    timer1.Interval = 5000;

                    caso = 1;
                    break;

                case 1:
                    ptbImagen.Image = TrabajoSemaforo.Properties.Resources.Amarillo;
                    ptbImagen2.Image = TrabajoSemaforo.Properties.Resources.Amarillo;

                    timer1.Interval = 2000;

                    caso = 2;
                    break;

                case 2:
                    ptbImagen.Image = TrabajoSemaforo.Properties.Resources.Rojo;
                    ptbImagen2.Image = TrabajoSemaforo.Properties.Resources.Verde;

                    timer1.Interval = 5000;

                    caso = 0;
                    break;
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            if (btnDetener.Text == "Detener")
            {
                timer1.Enabled = false;

                btnDetener.Text = "Reanudar";

                label1.Text = "Detenido";
            }
            else if(btnDetener.Text=="Reanudar")
            {
                timer1.Enabled = true;

                btnDetener.Text = "Detener";

                label1.Text = "Encendido";
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            btnDetener.Enabled = false;
            btnApagar.Enabled = false;

            btnEncender.Enabled = true;

            ptbImagen.Image = TrabajoSemaforo.Properties.Resources.Apagado;
            ptbImagen2.Image = TrabajoSemaforo.Properties.Resources.Apagado;

            label1.Text = "Apagado";
        }
    }
}
