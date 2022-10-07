using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PracticaSubproceso
{
    public partial class TrabajoHilos : Form
    {
        // Contadores de los hilos
        public int counter = 0;
        public int counter1 = 0;
        public int counter2 = 0;
        public int counter3 = 0;
        public Random random = new Random();
        //Se establece el timer
        public TrabajoHilos()
        {
            InitializeComponent();

            timer1.Interval = 1;
            timer1.Enabled = true;
            timer1.Start();

            initializeProgressBars();
        }
        //Se establece los valores de las barras de progreso
        private void initializeProgressBars()
        {

            progressBar1.Step = 1;
            progressBar2.Step = 1;
            progressBar3.Step = 1;
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar1.Maximum = 100;
            progressBar2.Maximum = 100;
            progressBar3.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar2.Minimum = 0;
            progressBar3.Minimum = 0;
        }

        //Funciones del boton de inicio
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text=="Inicio")
            {
                button1.Enabled = false;
                button2.Enabled = true;

                // Creando el hilo 1
                ThreadStart newThread1 = new ThreadStart(thread1);
                Thread t1 = new Thread(newThread1);
                t1.Start();
                // Creando el hilo 2
                ThreadStart newThread2 = new ThreadStart(thread2);
                Thread t2 = new Thread(newThread2);
                t2.Start();
                // Creando el hilo 3
                ThreadStart newThread3 = new ThreadStart(thread3);
                Thread t3 = new Thread(newThread3);
                t3.Start();
            }
            else if (button1.Text=="Continuar")
            {
                timer1.Start();

                button1.Enabled = false;
                button2.Enabled = true;
                button1.Text = "Inicio";
            }

        }

        // Contador de progreso por 1
        private void thread1()
        {
            for (int i = 0; counter1 < 1000000000; i++)
                counter1=counter1+random.Next(20, 60);
        }
        // Contador de progreso por 2
        private void thread2()
        {
            for (int i = 0; counter2 < 1000000000; i++)
                counter2= counter2 + random.Next(20, 60);
        }
        // Contador de progreso por 4
        private void thread3()
        {
            for (int i = 0; counter3 < 1000000000; i++)
                counter3= counter3 + random.Next(20, 60);
        }

        // Mostrar el contador para cada hilo
        private void timer1_Tick(object sender, EventArgs e)
        {
            double tmp = 0.00;
            counter++;
            //Se despliega el valor de tiempo en los textbox
            textBox4.Text = counter.ToString();
            textBox1.Text = counter1.ToString();
            textBox2.Text = counter2.ToString();
            textBox3.Text = counter3.ToString();
            if (counter1 > 1)
            {
                tmp = ((double)counter1 / 1000000000) * 100;
                progressBar1.Value = (int)tmp;
                tmp = ((double)counter2 / 1000000000) * 100;
                progressBar2.Value = (int)tmp;
                tmp = ((double)counter3 / 1000000000) * 100;
                progressBar3.Value = (int)tmp;

            }
        }

        //Funciones para el boton de detener
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();

            button1.Enabled = true;
            button2.Enabled = false;
            button1.Text = "Continuar";
        }
    }
}
