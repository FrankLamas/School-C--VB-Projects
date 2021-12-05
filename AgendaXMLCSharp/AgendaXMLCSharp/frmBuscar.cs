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

namespace AgendaXMLCSharp
{
    public partial class frmBuscar : Form
    {
        string ruta;
        public frmBuscar()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean x = false;
                ruta = Application.StartupPath + "\\contacto.xml";
                xmlOperaciones mostrar = new xmlOperaciones(ruta);
                string[] datos = mostrar.leerXML();
                for (int i = 0; i < datos.Length; i++)
                {
                    String[] registro = datos[i].Split(',');
                    if (registro[0]==tID.Text)
                    {
                        tNombre.Text = registro[1];
                        tDom.Text = registro[2];
                        tTelefono.Text = registro[3];
                        tCorreo.Text = registro[4];
                        x = true;
                    }
                }
                if (x != true)
                {
                    MessageBox.Show(this, "No se encontraron coincidencias", "Sin resultados");
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(this, "No se encuentra el archivo", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBuscar_Load(object sender, EventArgs e)
        {

        }
    }
}
