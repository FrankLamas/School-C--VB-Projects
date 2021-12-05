using System;
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
    public partial class MenuP : Form
    {
        public MenuP()
        {
            InitializeComponent();
        }

        private void agregarContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAgregarContacto f = new FormAgregarContacto();
            f.ShowDialog();
        }

        private void mostrarContactosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactosMostrar cm = new ContactosMostrar();
            cm.ShowDialog();
        }

        private void MenuP_Load(object sender, EventArgs e)
        {

        }

        private void buscarContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contactosBuscar cb = new contactosBuscar();
            cb.ShowDialog();
        }

        private void modificarContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contactosEditar ce = new contactosEditar();
            ce.ShowDialog();
        }

        private void eliminarContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contactosEliminar ce = new contactosEliminar();
            ce.ShowDialog();
        }
    }
}
