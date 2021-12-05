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
    public partial class FormEditarNota : Form
    {
        int id;
        public FormEditarNota(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void actualizarProveedores()
        {
            cmbProveedor.DataSource = null;
            cmbProveedor.Items.Clear();
            Operaciones op = new Operaciones();
            DataTable dt = op.datosProveedor();
            cmbProveedor.DataSource = dt;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "idProveedor";

            cmbProveedor.SelectedIndex = 0;
            cmbProveedor.Refresh();
        }

        private void FormEditarNota_Load(object sender, EventArgs e)
        {
            actualizarProveedores();
            Operaciones op = new Operaciones();
            DataTable dt = op.datosNota(id);
            dtpFecha.Text = dt.Rows[0]["Fecha"].ToString();
            tIDNota.Text = dt.Rows[0]["IdNota"].ToString();
            tDeuda.Text = dt.Rows[0]["Deuda"].ToString();
            cmbProveedor.SelectedValue = Convert.ToInt16(dt.Rows[0]["idProveedor"].ToString());
        }

        private void tDeuda_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            FormAgregarProveedor fap = new FormAgregarProveedor();
            fap.ShowDialog();
            actualizarProveedores();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tIDNota.Text != "" && tDeuda.Text != "" && cmbProveedor.Text != "")
                {
                    Operaciones op = new Operaciones();
                    op.EditarNota(id,tIDNota.Text, Convert.ToDouble(tDeuda.Text), dtpFecha.Text, Convert.ToInt16(cmbProveedor.SelectedValue));
                    MessageBox.Show(this, "Terminó la captura.", "Información");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Hubo un error: " + ex.Message, "Error");
            }
        }
    }
}
