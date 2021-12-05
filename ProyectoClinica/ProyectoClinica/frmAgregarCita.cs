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
    public partial class frmAgregarCita : Form
    {
        public frmAgregarCita()
        {
            InitializeComponent();
        }

        private void tNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgregarCita_Load(object sender, EventArgs e)
        {
            operaciones op = new operaciones();
            dgvPaciente.DataSource = op.datosParaGrid("paciente");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            operaciones op = new operaciones();
            dgvPaciente.DataSource = op.filtroParaPaciente(textBox1.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tNombre.Text!="")
            {
                operaciones op = new operaciones();
                op.agregarCita(Convert.ToInt16(dgvPaciente.CurrentRow.Cells[0].Value.ToString()),dtpFecha.Text,dtpHora.Text,tNombre.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show(this,"No puedes crear la cita sin especificar el nombre del medico que atiende.","Alerta");
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
