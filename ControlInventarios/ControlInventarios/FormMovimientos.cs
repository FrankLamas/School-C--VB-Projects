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
    public partial class FormMovimientos : Form
    {
        string cmbFiltro="!='estono'";
        public FormMovimientos()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void actualizarDGV()
        {
            dataGridView1.Rows.Clear();
            Operaciones op = new Operaciones();
            //Así se recorre un datatable ;)
            DataTable dt = op.gridMovimientos();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i]["Fecha"], dt.Rows[i]["Tipo"], dt.Rows[i]["Total"], dt.Rows[i]["Modelo"], dt.Rows[i]["Cantidad"], dt.Rows[i]["idMovimiento"]);
            }
        }

        private void filtro() {
            dataGridView1.Rows.Clear();
            Operaciones op = new Operaciones();
            //Así se recorre un datatable ;)
            DataTable dt = op.filtroMovimientos(comboBox1.Text,textBox1.Text,cmbFiltro);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i]["Fecha"], dt.Rows[i]["Tipo"], dt.Rows[i]["Total"], dt.Rows[i]["Modelo"], dt.Rows[i]["Cantidad"], dt.Rows[i]["idMovimiento"]);
            }
        }

        private void FormMovimientos_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAgregarMovimiento fam = new FormAgregarMovimiento();
            fam.ShowDialog();
            actualizarDGV();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Todo")
                cmbFiltro = "!='estono'";
            else if (comboBox2.Text == "Entradas")
                cmbFiltro = "='Entrada'";
            else
                cmbFiltro = "='Salida'";

            filtro();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FormEditarMovimiento fem = new FormEditarMovimiento(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                fem.ShowDialog();
                actualizarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pude realizar esta acción. Excepción: "+ex.Message,"Error");
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FormEliminarMovimiento fem = new FormEliminarMovimiento(dataGridView1.CurrentRow.Cells[0].Value.ToString(), Convert.ToInt16(dataGridView1.CurrentRow.Cells[5].Value.ToString()));
                fem.ShowDialog();
                actualizarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pude realizar esta acción. Excepción: "+ex.Message,"Error");
            }
            
        }
    }
}
