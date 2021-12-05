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
    public partial class FormAbonosNotas : Form
    {
        int id;
        public FormAbonosNotas(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void actualizarDGV()
        {
            dataGridView1.Rows.Clear();
            Operaciones op = new Operaciones();
            //Así se recorre un datatable ;)
            DataTable dt = op.datosAbonosProv(id);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i]["Fecha"], dt.Rows[i]["Cantidad"], dt.Rows[i]["idabonosclientes"]);
            }
        }

        private void FormAbonosNotas_Load(object sender, EventArgs e)
        {
            Operaciones op = new Operaciones();
            DataTable dt = op.datosNota(id);
            lbDeuda.Text = dt.Rows[0]["Deuda"].ToString();
            lbIDNota.Text = dt.Rows[0]["IdNota"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FormNuevoAbonoProv fnap = new FormNuevoAbonoProv(id);
                fnap.ShowDialog();
                actualizarDGV();
                Operaciones op = new Operaciones();
                DataTable dt = op.datosNota(id);
                lbDeuda.Text = dt.Rows[0]["Deuda"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"No se puede realizar la siguiente acción. Error: "+ex.Message,"Error");
            }
        }
    }
}
