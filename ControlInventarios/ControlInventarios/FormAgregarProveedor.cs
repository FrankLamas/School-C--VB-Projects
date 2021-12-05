using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlInventarios
{
    public partial class FormAgregarProveedor : Form
    {
        public FormAgregarProveedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tNombre.Text!="" && tTelefono.Text!="" &&tCuenta.Text!="")
                {
                    Operaciones op = new Operaciones();
                    op.agregarProveedor(tNombre.Text, tTelefono.Text, Convert.ToDouble(tCuenta.Text));
                    MessageBox.Show(this, "Finalizó captura.", "Información");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this,"Los datos inconclusos no se aceptan en el programa","Información");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: "+ ex.Message,"Error");
            }
        }

        private void tCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsDigit(e.KeyChar) || Char.Equals(e.KeyChar, '.') || Char.Equals(e.KeyChar,'-'))
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
            if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsWhiteSpace(e.KeyChar))
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

        private void tTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
