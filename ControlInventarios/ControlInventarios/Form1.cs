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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelPant_Paint(object sender, PaintEventArgs e)
        {

        }

        private void abrirFormEnPanel(object FormH) {
            if (this.panelPant.Controls.Count > 0)
                this.panelPant.Controls.RemoveAt(0);
            Form f = FormH as Form;
            f.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.panelPant.Controls.Add(f);
            this.panelPant.Tag = f;
            f.Show();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Pantalla_de_Bienvenida pb = new Pantalla_de_Bienvenida();
            abrirFormEnPanel(pb);
            if (DateTime.Now.Day>0 && DateTime.Now.Day<4)
            {
                MessageBox.Show(this,"Son los primeros días del mes, se recomienda generar un documento con el inventario y movimientos completos para tener un respaldo de los mismos.","Recomendación");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormInventario fi = new FormInventario();
            abrirFormEnPanel(fi);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMovimientos fm = new FormMovimientos();
            abrirFormEnPanel(fm);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormReportes fr = new FormReportes();
            abrirFormEnPanel(fr);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormProveedores fp = new FormProveedores();
            abrirFormEnPanel(fp);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormClientes fc = new FormClientes();
            abrirFormEnPanel(fc);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormNotasProveedor fnp = new FormNotasProveedor();
            abrirFormEnPanel(fnp);
        }
    }
}
