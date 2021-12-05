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
    public partial class frmAgregarHistoria : Form
    {
        public frmAgregarHistoria()
        {
            InitializeComponent();
        }

        private void frmAgregarHistoria_Load(object sender, EventArgs e)
        {
            operaciones op = new operaciones();
            dgvCitas.DataSource = op.datosParaGridCitas();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            operaciones op = new operaciones();
            dgvCitas.DataSource = op.filtroCita(tfiltro.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tPadecimiento.Text!=""||tTratamiento.Text!="")
            {
                operaciones op = new operaciones();
                op.agregarHistoria(Convert.ToInt16(dgvCitas.CurrentRow.Cells[1].Value.ToString()), tPadecimiento.Text, tTratamiento.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "No puedes guardar el registro dejando campos vacios", "Alerta");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tPadecimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tPadecimiento.Text == "")
                {
                    tPadecimiento.Focus();
                }
                else
                {
                    tTratamiento.Focus();
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

        private void tTratamiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tTratamiento.Text == "")
                {
                    tTratamiento.Focus();
                }
                else
                {
                    tPadecimiento.Focus();
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

    }
}
