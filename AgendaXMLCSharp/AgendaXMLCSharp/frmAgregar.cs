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
    public partial class frmAgregar : Form
    {
        string ruta;
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ruta = Application.StartupPath + "\\contacto.xml";
                xmlOperaciones xo = new xmlOperaciones(ruta);
                if (File.Exists(ruta))
                {
                    xo.addElemento(tID.Text, tNombre.Text, tDom.Text, tTelefono.Text, tCorreo.Text);
                    MessageBox.Show(this, "Operación exitosa", "Registro guardado.");
                    this.Close();
                }
                else {
                    xo.crearXml(ruta);
                    xo.addElemento(tID.Text, tNombre.Text, tDom.Text, tTelefono.Text, tCorreo.Text);
                    MessageBox.Show(this, "Operación exitosa archivo creado", "Registro guardado.");
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"Error", ex.Message);
            }
            
        }
    }
}
