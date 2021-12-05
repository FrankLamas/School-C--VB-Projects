using DGVPrinterHelper;
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
    public partial class FormInventario : Form
    {
        public FormInventario()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAgregarElemto fae = new FormAgregarElemto();
            fae.ShowDialog();
            actualizarDGV();
        }

        private void actualizarDGV() {
            dataGridView1.Rows.Clear();
            Operaciones op = new Operaciones();
            //Así se recorre un datatable ;)
            DataTable dt = op.gridInventario();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object imagen = @dt.Rows[i]["Foto"];
                DataTable dtprov = op.datosProveedor(Convert.ToInt16(dt.Rows[i]["idProveedor"]));
                dataGridView1.Rows.Add(imagen, dt.Rows[i]["Modelo"], dt.Rows[i]["Numeracion"], dt.Rows[i]["Stock"], dt.Rows[i]["Tipo"], dt.Rows[i]["Precio"],dt.Rows[i]["PrecioCompra"], dt.Rows[i]["Color"],dt.Rows[i]["Nombre"], dt.Rows[i]["idZapatos"]);
            }
            CantMerc.Text = op.calcularDineroInventario().ToString()+" $";
        }

        private void filtro()
        {
            dataGridView1.Rows.Clear();
            Operaciones op = new Operaciones();
            //Así se recorre un datatable ;)
            DataTable dt = op.gridFiltroInventario(comboBox1.Text,textBox1.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object imagen = @dt.Rows[i]["Foto"];
                dataGridView1.Rows.Add(imagen, dt.Rows[i]["Modelo"], dt.Rows[i]["Numeracion"], dt.Rows[i]["Stock"], dt.Rows[i]["Tipo"], dt.Rows[i]["Precio"],dt.Rows[i]["PrecioCompra"], dt.Rows[i]["Color"],dt.Rows[i]["Nombre"], dt.Rows[i]["idZapatos"]);
            }
        }
        
        private void FormInventario_Load(object sender, EventArgs e)
        {
            actualizarDGV();
            comboBox1.SelectedIndex = 0;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (this.dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Foto":
                    if (e.Value!=null)
                    {
                        try
                        {
                            e.Value = Image.FromFile(e.Value.ToString());
                        }
                        catch (System.IO.FileLoadException ex)
                        {
                            MessageBox.Show(this,"La imagen no se encontro","Error");
                            e.Value = null;
                        }catch(Exception ex){
                            MessageBox.Show(this,"Error: "+ex.Message,"Error");
                        }
                    }
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FormEditarElemto fee = new FormEditarElemto(Convert.ToInt16(dataGridView1.CurrentRow.Cells[9].Value.ToString()));
                fee.ShowDialog();
                actualizarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pude realizar esta acción. Excepción: "+ex.Message,"Error");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                FormEliminarElemento fee = new FormEliminarElemento(dataGridView1.CurrentRow.Cells[1].Value.ToString(), Convert.ToInt16(dataGridView1.CurrentRow.Cells[9].Value.ToString()));
                fee.ShowDialog();
                actualizarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pude realizar esta acción. Excepción: "+ex.Message,"Error");
            }
            
        }

        Bitmap bmp;

        private void button4_Click(object sender, EventArgs e)
        {
            ////var dt = (DataTable)dataGridView1.DataSource;
            Operaciones op = new Operaciones();
            DataTable dt = op.gridInventario();
            FormImprimirInventario fii = new FormImprimirInventario(dt);
            fii.ShowDialog();
            //int heigth = dataGridView1.Height;
            //dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            //bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            //dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            //dataGridView1.Height = heigth;
            //printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp,0,0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtro();
        }
    }
}
