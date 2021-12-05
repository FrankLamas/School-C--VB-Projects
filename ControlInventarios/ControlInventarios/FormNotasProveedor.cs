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
    public partial class FormNotasProveedor : Form
    {
        string columna = "IdNota";
        public FormNotasProveedor()
        {
            InitializeComponent();
        }

        private void filtro()
        {
            dataGridView1.Rows.Clear();
            Operaciones op = new Operaciones();
            //Así se recorre un datatable ;)
            DataTable dt = op.FiltroNotas(columna, textBox1.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i]["IdNota"], dt.Rows[i]["Deuda"], dt.Rows[i]["Fecha"], dt.Rows[i]["Nombre"], dt.Rows[i]["idNotasProveedor"]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text=="Proveedor")
            {
                columna = "Nombre";
            }
            else
            {
                columna = comboBox1.Text;
            }
            filtro();
        }

        private void actualizarDGV()
        {
            dataGridView1.Rows.Clear();
            Operaciones op = new Operaciones();
            //Así se recorre un datatable ;)
            DataTable dt = op.datosNotas();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i]["IdNota"], dt.Rows[i]["Deuda"], dt.Rows[i]["Fecha"], dt.Rows[i]["Nombre"], dt.Rows[i]["idNotasProveedor"]);
            }
            CantMerc.Text = op.calcularDeudaProv().ToString() + " $";
        }

        private void FormNotasProveedor_Load(object sender, EventArgs e)
        {
            actualizarDGV();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNuevaNota fnn = new FormNuevaNota();
            fnn.ShowDialog();
            actualizarDGV();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormEditarNota fen = new FormEditarNota(Convert.ToInt16(dataGridView1.CurrentRow.Cells[4].Value.ToString()));
            fen.ShowDialog();
            actualizarDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FormAbonosNotas fan = new FormAbonosNotas(Convert.ToInt16(dataGridView1.CurrentRow.Cells[4].Value.ToString()));
                fan.ShowDialog();
                actualizarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"No sé puede realizar la siguiente acción. Error: "+ex.Message,"Error");
            }
        }
    }
}
