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
    public partial class FormEditarCliente : Form
    {
        int id;
        public FormEditarCliente(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void FormEditarCliente_Load(object sender, EventArgs e)
        {
            Operaciones op = new Operaciones();
            DataTable dt = op.datosClientes(id);
            tNombre.Text = dt.Rows[0]["Nombre"].ToString();
            tCiudad.Text = dt.Rows[0]["Ciudad"].ToString();
            tDomicilio.Text = dt.Rows[0]["Domicilio"].ToString();
            tRuta.Text = dt.Rows[0]["Ruta"].ToString();
            tTelefono.Text = dt.Rows[0]["Telefono"].ToString();
            tCP.Text = dt.Rows[0]["CP"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tNombre.Text = "";
            tCiudad.Text = "";
            tDomicilio.Text = "";
            tRuta.Text = "";
            tTelefono.Text = "";
            tCP.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void tCiudad_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsNumber(e.KeyChar))
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
                if (tNombre.Text != "" && tCiudad.Text != "" && tDomicilio.Text != "" && tRuta.Text != "" && tTelefono.Text != "" && tCP.Text != "")
                {
                    Operaciones op = new Operaciones();
                    op.editarCliente(id,tNombre.Text, tCiudad.Text, tDomicilio.Text, tRuta.Text, tTelefono.Text, tCP.Text);
                    MessageBox.Show(this, "La captura finalizó.", "Información");
                    this.Close();
                }
                else
                    MessageBox.Show(this, "No se puede capturar a menos que todos los campos estén llenos. Si no tienes todos los datos puedes escribir algo y mas tarde editarlo.", "Advertencia");

            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"Error: "+ex.Message,"Error");
            }
        }
    }
}
