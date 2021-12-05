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
    public partial class FormAbonosCliente : Form
    {
        int id;
        public FormAbonosCliente(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsDigit(e.KeyChar) || Char.Equals(e.KeyChar, '.') || Char.Equals(e.KeyChar, '-'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void actualizarDGV()
        {
            dataGridView1.Rows.Clear();
            Operaciones op = new Operaciones();
            //Así se recorre un datatable ;)
            DataTable dt = op.datosAbonosClientes(id);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i]["Fecha"], dt.Rows[i]["Cantidad"], dt.Rows[i]["EstadoAdeudo"], dt.Rows[i]["idabonosclientes"]);
            }
            dt = op.datosCargos(id);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i]["Fecha"], dt.Rows[i]["Cantidad"], dt.Rows[i]["idcargoscliente"]);
            }
        }

        private void FormAbonosCliente_Load(object sender, EventArgs e)
        {
            Operaciones op = new Operaciones();
            DataTable dt = op.datosClientes(id);
            lbNombre.Text = dt.Rows[0]["Nombre"].ToString();
            tAdeudo.Text = dt.Rows[0]["Adeudo"].ToString();
            actualizarDGV();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Operaciones op = new Operaciones();
                op.editarAdeudoCliente(id,Convert.ToDouble(tCantidad.Text));
                DataTable dt = op.datosClientes(id);
                tAdeudo.Text = dt.Rows[0]["Adeudo"].ToString();
                tCantidad.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se puede realizar la siguiente acción, quizas los datos que ingresas estan equivocados. Error: "+ex.Message,"Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FormNuevoAbonoC fnac = new FormNuevoAbonoC(id);
                fnac.ShowDialog();
                actualizarDGV();
                Operaciones op = new Operaciones();
                DataTable dt = op.datosClientes(id);
                tAdeudo.Text = dt.Rows[0]["Adeudo"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se puede realizar la siguiente acción. Error: " + ex.Message, "Error");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                FormNuevoCargoC fncc = new  FormNuevoCargoC(id);
                fncc.ShowDialog();
                actualizarDGV();
                Operaciones op = new Operaciones();
                DataTable dt = op.datosClientes(id);
                tAdeudo.Text = dt.Rows[0]["Adeudo"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se puede realizar la siguiente acción. Error: " + ex.Message, "Error");
            }
        }
    }
}
