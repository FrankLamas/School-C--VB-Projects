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

namespace Agenda
{
    public partial class ContactosMostrar : Form
    {
        String ruta;
        public ContactosMostrar()
        {
            InitializeComponent();
        }

        private void ContactosMostrar_Load(object sender, EventArgs e)
        {
            try
            {
                String registro;
                ruta = Application.StartupPath + "\\contacto.txt";
                using (StreamReader sr = new StreamReader(ruta))
                {
                    while ((registro = sr.ReadLine()) != null)
                    {
                        String[] datos = registro.Split(',');
                        this.dgvContactos.Rows.Add(datos[0], datos[1], datos[2], datos[3], datos[4]);
                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException f)
            {
                MessageBox.Show(this, "No se encuentra el archivo", "Error");
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
