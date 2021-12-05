using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaMenu
{
    public partial class FrmCalculadora : Form
    {
        int primervalor = 0;

        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            picUno.Image = Image.FromFile("C:\\Users\\Laboratorio.LAB3-PC12\\Documents\\Visual Studio 2012\\Projects\\PruebaMenu\\imgs calculadora\\1.png");
            pic2.Image = Image.FromFile("C:\\Users\\Laboratorio.LAB3-PC12\\Documents\\Visual Studio 2012\\Projects\\PruebaMenu\\imgs calculadora\\2.png");
            pic3.Image = Image.FromFile("C:\\Users\\Laboratorio.LAB3-PC12\\Documents\\Visual Studio 2012\\Projects\\PruebaMenu\\imgs calculadora\\3.png");
            pic4.Image = Image.FromFile("C:\\Users\\Laboratorio.LAB3-PC12\\Documents\\Visual Studio 2012\\Projects\\PruebaMenu\\imgs calculadora\\4.png");
            pic5.Image = Image.FromFile("C:\\Users\\Laboratorio.LAB3-PC12\\Documents\\Visual Studio 2012\\Projects\\PruebaMenu\\imgs calculadora\\5.png");
            pic6.Image = Image.FromFile("C:\\Users\\Laboratorio.LAB3-PC12\\Documents\\Visual Studio 2012\\Projects\\PruebaMenu\\imgs calculadora\\6.png");
            pic7.Image = Image.FromFile("C:\\Users\\Laboratorio.LAB3-PC12\\Documents\\Visual Studio 2012\\Projects\\PruebaMenu\\imgs calculadora\\7.png");
            pic8.Image = Image.FromFile("C:\\Users\\Laboratorio.LAB3-PC12\\Documents\\Visual Studio 2012\\Projects\\PruebaMenu\\imgs calculadora\\8.png");
            pic9.Image = Image.FromFile("C:\\Users\\Laboratorio.LAB3-PC12\\Documents\\Visual Studio 2012\\Projects\\PruebaMenu\\imgs calculadora\\9.png");
            pic0.Image = Image.FromFile("C:\\Users\\Laboratorio.LAB3-PC12\\Documents\\Visual Studio 2012\\Projects\\PruebaMenu\\imgs calculadora\\0.png");
        }

        private void picUno_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "1";
            }
            else
            {
                txtResultado.Text = txtResultado.Text + "1";
            }
        }

        private void pic2_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "2";
            }
            else
            {
                txtResultado.Text = txtResultado.Text + "2";
            }
        }

        private void pic3_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "3";
            }
            else
            {
                txtResultado.Text = txtResultado.Text + "3";
            }
        }

        private void pic4_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "4";
            }
            else
            {
                txtResultado.Text = txtResultado.Text + "4";
            }
        }

        private void pic5_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "5";
            }
            else
            {
                txtResultado.Text = txtResultado.Text + "5";
            }
        }

        private void pic6_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "6";
            }
            else
            {
                txtResultado.Text = txtResultado.Text + "6";
            }
        }

        private void pic7_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "7";
            }
            else
            {
                txtResultado.Text = txtResultado.Text + "7";
            }
        }

        private void pic8_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "8";
            }
            else
            {
                txtResultado.Text = txtResultado.Text + "8";
            }
        }

        private void pic9_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "9";
            }
            else
            {
                txtResultado.Text = txtResultado.Text + "9";
            }
        }

        private void pic0_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "0";
            }
            else
            {
                txtResultado.Text = txtResultado.Text + "0";
            }
        }

        private void btnsuma_Click(object sender, EventArgs e)
        {
            if(primervalor != 0 && txtResultado.Text!="0"){
                primervalor = Convert.ToInt16(txtResultado.Text);
                txtResultado.Text = "0";
            }
        }

        private void btnresta_Click(object sender, EventArgs e)
        {
            if (primervalor != 0 && txtResultado.Text != "0")
            {
                primervalor = Convert.ToInt16(txtResultado.Text);
                txtResultado.Text = "0";
            }
        }

        private void btnmultiplica_Click(object sender, EventArgs e)
        {
            if (primervalor != 0 && txtResultado.Text != "0")
            {
                primervalor = Convert.ToInt16(txtResultado.Text);
                txtResultado.Text = "0";
            }
        }

        private void btndivide_Click(object sender, EventArgs e)
        {
            if (primervalor != 0 && txtResultado.Text != "0")
            {
                primervalor = Convert.ToInt16(txtResultado.Text);
                txtResultado.Text = "0";
            }
        }
    }
}
