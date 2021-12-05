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
    public partial class FormEliminarElemento : Form
    {
        string modelo;
        int id;
        public FormEliminarElemento(string modelo,int id)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.id = id;
        }

        private void FormEliminarElemento_Load(object sender, EventArgs e)
        {
            label2.Text = "Estás seguro de que eliminar el modelo: " + modelo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Operaciones op = new Operaciones();
                //if (System.IO.File.Exists(Application.StartupPath + @"\Imagenes\" + modelo + ".jpg"))
                //    System.IO.File.Delete(Application.StartupPath + @"\Imagenes\" + modelo + ".jpg");
                op.eliminarElemento(id);
                MessageBox.Show(this,"Elemento eliminado con éxito.","Información");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"Error: "+ex.Message,"Ecepción");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
