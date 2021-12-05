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
    public partial class FormNuevaNota : Form
    {
        public FormNuevaNota()
        {
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

        private void button6_Click(object sender, EventArgs e)
        {
            FormAgregarProveedor fap = new FormAgregarProveedor();
            fap.ShowDialog();
            actualizarProveedores();
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormNuevaNota_Load(object sender, EventArgs e)
        {
            actualizarProveedores();
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tIDNota.Text!=""&&tDeuda.Text!=""&& cmbProveedor.Text!="")
                {
                    Operaciones op = new Operaciones();
                    op.agregarNota(tIDNota.Text,Convert.ToDouble(tDeuda.Text),dtpFecha.Text,Convert.ToInt16(cmbProveedor.SelectedValue));
                    MessageBox.Show(this,"Terminó la captura.","Información");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"Hubo un error: "+ex.Message,"Error");
            }
        }
    }
}
