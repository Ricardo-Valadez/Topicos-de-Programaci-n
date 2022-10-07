using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_Sencilla
{
    public partial class Form1 : Form
    {
        double  Resultado;

        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            float x1, x2,res;
            x1 = System.Single.Parse(txtValor1.Text);
            x2 = System.Single.Parse(txtValor2.Text);

            if (rbSuma.Checked == true)
            {
                res = x1 + x2;
                lbResultado.Text = res.ToString();
            }
            else if (rbResta.Checked == true)
            {
                res = x1 - x2;
                lbResultado.Text = res.ToString();
            }
            else if (rbMulti.Checked == true)
            {
                res = x1 * x2;
                lbResultado.Text = res.ToString();
            }
            else if (rbDivi.Checked == true)
            {
                res = x1 / x2;
                lbResultado.Text = res.ToString();
            }
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
