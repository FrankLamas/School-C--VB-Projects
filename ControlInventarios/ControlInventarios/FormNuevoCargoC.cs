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
    public partial class FormNuevoCargoC : Form
    {
        int id;
        public FormNuevoCargoC(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Operaciones op = new Operaciones();
                op.editarAdeudoCliente(id, Convert.ToDouble("+" + tCantidad.Text));
                DataTable dt = op.datosClientes(id);
                op.agregarCargo(id, dateTimePicker1.Text, Convert.ToDouble(tCantidad.Text));
                MessageBox.Show(this, "Fin de la captura.", "Información");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Error");
            }
        }

        private void tCantidad_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
