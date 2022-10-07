using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingreso_Hospital
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Los datos son:\nNombre: Ricardo Valadez Leal\nEdad: 20\nCiudad: Tijuana\nIngreso: Checkeo\nGenero: Masculino\nSintomas: Fiebre, Tos", "Datos del paciente", MessageBoxButtons.OK);
            return;
        }
    }
}
