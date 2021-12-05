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

namespace ActividadesComplementarias
{
    public partial class actividadesAgregar : Form
    {
        String ruta;
        public actividadesAgregar()
        {
            InitializeComponent();
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (tID.Text == "" || tNombre.Text == "")
            {
                MessageBox.Show(this,"No puede haber campos vacios","Error");
            }
            else
            {
                try
                {
                    ruta = Application.StartupPath + "\\Actividad.txt";
                    using (StreamWriter sw = File.AppendText(ruta))
                    {
                        sw.WriteLine(tID.Text + "," + tNombre.Text + "," + "N/A" + "," + "N/A" + "," + "N/A" + "," + "N/A" + "," + 0);
                        sw.Close();
                        MessageBox.Show(this, "Registro Guardado", "Operación Realizada");
                        this.Close();
                    }
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

        

        private void actividadesAgregar_Load(object sender, EventArgs e)
        {
            
        }
    }
}
