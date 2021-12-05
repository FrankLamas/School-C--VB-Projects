using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class FormAgregarContacto : Form
    {
        String ruta;
        public FormAgregarContacto()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tID.Text == "")
                {
                    tID.Focus();
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

        private void tTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tTelefono.Text == "")
                {
                    tTelefono.Focus();
                }
                else
                {
                    tCorreo.Focus();
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
                    tDomicilio.Focus();
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
            else {
                e.Handled = true;
            }
        }

        private void tDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tDomicilio.Text == "")
                {
                    tDomicilio.Focus();
                }
                else
                {
                    tTelefono.Focus();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (tNombre.Text.Equals("") || tID.Text == "" || tDomicilio.Text == "" || tTelefono.Text == "" || tCorreo.Text == "")
            {
                MessageBox.Show(this, "No puede haber casillas vacias", "Error");
            }
            else
            {
                try
                {
                    ruta = Application.StartupPath + "\\contacto.txt";
                    using (StreamWriter sw = File.AppendText(ruta))
                    {
                        sw.WriteLine(tID.Text + "," + tNombre.Text + "," + tDomicilio.Text + "," + tTelefono.Text + "," + tCorreo.Text);
                        sw.Close();
                        MessageBox.Show(this, "Registro Guardado", "Operación Realizada");
                    }
                    this.Close();
                }catch(FileNotFoundException){
                    MessageBox.Show(this, "No se encuentra el archivo.","Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error");
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tDomicilio.Text == "")
                {
                    tDomicilio.Focus();
                }
                else
                {
                    tTelefono.Focus();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.Equals(e.KeyChar, '-') || Char.Equals(e.KeyChar, '@') || Char.Equals(e.KeyChar, '_') || Char.Equals(e.KeyChar, '.'))
            {
                e.Handled = false;
            }
            else if (Char.IsLetterOrDigit(e.KeyChar))
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
