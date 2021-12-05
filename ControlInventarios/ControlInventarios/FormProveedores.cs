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
    public partial class FormProveedores : Form
    {
        public FormProveedores()
        {
            InitializeComponent();
        }

        private void filtro()
        {
            dataGridView1.Rows.Clear();
            Operaciones op = new Operaciones();
            //Así se recorre un datatable ;)
            DataTable dt = op.FiltroProveedor(comboBox1.Text, textBox1.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i]["Nombre"], dt.Rows[i]["Telefono"], dt.Rows[i]["Cuenta"], dt.Rows[i]["idProveedor"]);
            }
        }

        private void actualizarDGV()
        {
            dataGridView1.Rows.Clear();
            Operaciones op = new Operaciones();
            //Así se recorre un datatable ;)
            DataTable dt = op.datosProveedor();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i]["Nombre"], dt.Rows[i]["Telefono"], dt.Rows[i]["Cuenta"], dt.Rows[i]["idProveedor"]);
            }
            CantMerc.Text = op.calcularDeudaProveedores().ToString() + " $";
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            actualizarDGV();
            comboBox1.SelectedIndex = 0;
            Operaciones op = new Operaciones();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAgregarProveedor fap = new FormAgregarProveedor();
            fap.ShowDialog();
            actualizarDGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                EditarProveedor ep = new EditarProveedor(Convert.ToInt16(dataGridView1.CurrentRow.Cells[3].Value.ToString()));
                ep.ShowDialog();
                actualizarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pude realizar esta acción. Excepción: "+ex.Message,"Error");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtro();
        }
    }
}
