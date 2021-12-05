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
    public partial class EditarProveedor : Form
    {
        int id;
        public EditarProveedor(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void EditarProveedor_Load(object sender, EventArgs e)
        {
            Operaciones op = new Operaciones();
            DataTable dt = op.datosProveedor(id);
            tNombre.Text = dt.Rows[0]["Nombre"].ToString();
            tTelefono.Text = dt.Rows[0]["Telefono"].ToString();
            tCuenta.Text = dt.Rows[0]["Cuenta"].ToString();
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

        private void tCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsDigit(e.KeyChar) || Char.Equals(e.KeyChar, '.') || Char.Equals(e.KeyChar, '-'))
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tNombre.Text != "" && tTelefono.Text != "" && tCuenta.Text != "")
                {
                    Operaciones op = new Operaciones();
                    op.editarProveedor(id,tNombre.Text, tTelefono.Text, Convert.ToDouble(tCuenta.Text));
                    MessageBox.Show(this, "Finalizó captura.", "Información");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Los datos inconclusos no se aceptan en el programa", "Información");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Error");
            }
        }
    }
}
