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
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private void actualizarDGV()
        {
            dataGridView1.Rows.Clear();
            Operaciones op = new Operaciones();
            //Así se recorre un datatable ;)
            DataTable dt = op.datosClientes();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i]["Nombre"], dt.Rows[i]["Ciudad"], dt.Rows[i]["Domicilio"], dt.Rows[i]["Ruta"], dt.Rows[i]["Telefono"], dt.Rows[i]["CP"], dt.Rows[i]["Adeudo"], dt.Rows[i]["Gastado"], dt.Rows[i]["ParesComprados"], dt.Rows[i]["idClientes"]);
            }
            CantMerc.Text = op.calcularDeudaClientes().ToString() + " $";
        }

        private void filtro()
        {
            dataGridView1.Rows.Clear();
            Operaciones op = new Operaciones();
            //Así se recorre un datatable ;)
            DataTable dt = op.FiltroClientes(comboBox1.Text, textBox1.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i]["Nombre"], dt.Rows[i]["Ciudad"], dt.Rows[i]["Domicilio"], dt.Rows[i]["Ruta"], dt.Rows[i]["Telefono"], dt.Rows[i]["CP"], dt.Rows[i]["Adeudo"], dt.Rows[i]["Gastado"], dt.Rows[i]["ParesComprados"], dt.Rows[i]["idClientes"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAgregarCliente fac = new FormAgregarCliente();
            fac.ShowDialog();
            actualizarDGV();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            actualizarDGV();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FormEditarCliente fee = new FormEditarCliente(Convert.ToInt16(dataGridView1.CurrentRow.Cells[9].Value.ToString()));
                fee.ShowDialog();
                actualizarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pude realizar esta acción. Excepción: " + ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FormAbonosCliente fac = new FormAbonosCliente(Convert.ToInt16(dataGridView1.CurrentRow.Cells[9].Value.ToString()));
                fac.ShowDialog();
                actualizarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se puede realizar la siguiente acción. Error: "+ex.Message,"Error");
            }
            
        }
    }
}
