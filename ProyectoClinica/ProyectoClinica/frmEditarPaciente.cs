using ProyectoClinica.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoClinica
{
    public partial class frmEditarPaciente : Form
    {
        int id;
        public frmEditarPaciente(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void NuevaEntrada_Load(object sender, EventArgs e)
        {
            operaciones o = new operaciones();
            string[] datos = o.obtenerPaciente(id);
            tNombre.Text = datos[0];
            tEdad.Text = datos[1];
            cmbSexo.Text = datos[2];
            tEstatura.Text = datos[3];
            tPeso.Text =datos[4];
            tSeguroSocial.Text = datos[5];
        }

        private void NuevaEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A) {
                MessageBox.Show(this,"Ahperro","simon");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tNombre.Text != "" || tEdad.Text != "" || cmbSexo.Text != "")
            {
                operaciones op = new operaciones();
                op.editarPaciente(id, tNombre.Text, tEdad.Text, cmbSexo.Text, tEstatura.Text == "" ? 0 : Convert.ToDouble(tEstatura.Text), tPeso.Text == "" ? 0 : Convert.ToDouble(tPeso.Text), (tSeguroSocial.Text == "" ? "N/A" : tSeguroSocial.Text));
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "No puedes guardar el registro dejando campos vacios", "Alerta");
            }
            
        }

        private void tNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tNombre.Text == "")
                {
                    tNombre.Focus();
                }
                else
                {
                    tEdad.Focus();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tEdad.Text == "")
                {
                    tEdad.Focus();
                }
                else
                {
                    cmbSexo.Focus();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tEstatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tEstatura.Text == "")
                {
                    tEstatura.Focus();
                }
                else
                {
                    tPeso.Focus();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsDigit(e.KeyChar) || Char.Equals(e.KeyChar, '.'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tEstatura.Text == "")
                {
                    tPeso.Focus();
                }
                else
                {
                    tSeguroSocial.Focus();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsDigit(e.KeyChar) || Char.Equals(e.KeyChar, '.'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tSeguroSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tEstatura.Text == "")
                {
                    tSeguroSocial.Focus();
                }
                else
                {
                    tNombre.Focus();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
