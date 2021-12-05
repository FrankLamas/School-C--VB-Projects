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
    public partial class frmMostrar : Form
    {
        string ruta;
        public frmMostrar()
        {
            InitializeComponent();
        }

        private void frmMostrar_Load(object sender, EventArgs e)
        {
            try
            {
                ruta = Application.StartupPath + "\\contacto.xml";
                xmlOperaciones mostrar = new xmlOperaciones(ruta);
                string[] datos = mostrar.leerXML();
                for (int i = 0; i < datos.Length; i++)
                {
                    String[] registro = datos[i].Split(',');
                    this.dgvMostrar.Rows.Add(registro[0], registro[1], registro[2], registro[3], registro[4]);
                }
            }catch(FileNotFoundException){
                MessageBox.Show(this, "No se encuentra el archivo","Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
