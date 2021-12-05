using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoISR
{
    public partial class Form1 : Form
    {
        double sueldo=0;
        double div = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsDigit(e.KeyChar) || e.KeyChar.Equals('.'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sueldo = Convert.ToDouble(textBox1.Text);
                double li = 0, porcent = 0, cuota = 0;
                if (sueldo >= 0.01 && sueldo <= 6942.2 / div)
                {
                    li = 0.01;
                    porcent = .0192;
                    cuota = 0;
                }
                if (sueldo >= 6942.2 / div && sueldo <= 58922.16 / div)
                {
                    li = 6942.2;
                    porcent = .0640;
                    cuota = 133.28;
                }
                if (sueldo >= 58922.16 / div && sueldo <= 103550.44 / div)
                {
                    li = 58922.16;
                    porcent = .1088;
                    cuota = 3460.01;
                }
                if (sueldo >= 103550.44 / div && sueldo <= 120372.83 / div)
                {
                    li = 103550.44;
                    porcent = .16;
                    cuota = 8315.57;
                }
                if (sueldo >= 120372.83 / div && sueldo <= 144119.23 / div)
                {
                    li = 120372.83;
                    porcent = .1792;
                    cuota = 11007.14;
                }
                if (sueldo >= 144119.23 / div && sueldo <= 290667.75 / div)
                {
                    li = 144119.23;
                    porcent = .2136;
                    cuota = 15262.49;
                }
                if (sueldo >= 290667.75 / div && sueldo <= 458132.29 / div)
                {
                    li = 290667.75;
                    porcent = .2352;
                    cuota = 46565.26;
                }
                if (sueldo >= 458132.29 / div && sueldo <= 874650 / div)
                {
                    li = 458132.29;
                    porcent = .30;
                    cuota = 85952.92;
                }
                if (sueldo >= 874650 / div && sueldo <= 1166200 / div)
                {
                    li = 874650;
                    porcent = .32;
                    cuota = 210908.23;
                }
                if (sueldo >= 1166200 / div && sueldo <= 3498600 / div)
                {
                    li = 1166200;
                    porcent = .34;
                    cuota = 304204.21;
                }
                if (sueldo >= 3498600 / div)
                {
                    li = 291183.33;
                    porcent = .35;
                    cuota = 1097220.21;
                }
                double isr = (((sueldo - (li / div)) * porcent) + (cuota / div));
                if (comboBox1.Text != "")
                {
                    MessageBox.Show(this, "El ISR " + comboBox1.Text + " es de: $" + isr);
                }
                else
                {
                    MessageBox.Show(this, "Tienes que seleccionar una forma de calculo del ISR.","Selecciona la Modalidad");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("Diario"))
            {
                div = 365;
            }
            else if (comboBox1.Text.Equals("Semanal"))
            {
                div = 52;
            }
            else if (comboBox1.Text.Equals("Quincenal"))
            {
                div = 24;
            }
            else if (comboBox1.Text.Equals("Mensual"))
            {
                div = 12;
            }
            else if (comboBox1.Text.Equals("Anual"))
            {
                div = 1;
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
