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
    public partial class FormReportes : Form
    {
        string prov = "!=-1";
        string tipo = "!='asdasd'";
        public FormReportes()
        {
            InitializeComponent();
        }

        private void actualizarProveedores()
        {
            cmbProveedor.DataSource = null;
            cmbProveedor.Items.Clear();
            Operaciones op = new Operaciones();
            DataTable dt = op.datosProveedor();
            cmbProveedor.DataSource = dt;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "idProveedor";

            try
            {
                cmbProveedor.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Aún no hay proveedores agregados.", "Aviso");
            }
            cmbProveedor.Refresh();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            cmbTipoMov.SelectedIndex = 0;
            actualizarProveedores();
            grid();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void grid()
        {
            dataGridView1.Rows.Clear();
            Operaciones op = new Operaciones();
            //Así se recorre un datatable ;)
            DataTable dt = op.datosReporte(tipo,dtp1.Text,dtp2.Text,prov);
            DataTable dtm = op.datosRM(tipo, dtp1.Text, dtp2.Text);
            double totalSalidas=0,totalEntradas=0;
            
            for (int i = 0; i < dtm.Rows.Count; i++)
            {
                if (dtm.Rows[i]["Tipo"].ToString()=="Salida")
                {
                    totalSalidas = totalSalidas + Convert.ToDouble(dtm.Rows[i]["Total"].ToString());
                }else
                    totalEntradas = totalEntradas + Convert.ToDouble(dtm.Rows[i]["Total"].ToString());
            }

            lbEntradas.Text = totalEntradas.ToString();
            lbSalidas.Text = totalSalidas.ToString();
            lbGanancia.Text = (totalSalidas-totalEntradas).ToString();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i]["Fecha"], dt.Rows[i]["Tipo"], dt.Rows[i]["Total"], dt.Rows[i]["Modelo"], dt.Rows[i]["Cantidad"], dt.Rows[i]["Precio"], dt.Rows[i]["Color"], dt.Rows[i]["Numeracion"]);
            }
        }

        private void cmbTipoMov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoMov.Text == "Todo")
                tipo = "!='estono'";
            else if (cmbTipoMov.Text == "Entradas")
                tipo = "='Entrada'";
            else
                tipo = "='Salida'";

            grid();
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            grid();
        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            grid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Reporte de Movimientos";
                printer.SubTitle = "De: " + dtp1.Text + " - " + dtp2.Text+". Compras: "+lbEntradas.Text+"$"+", Ventas: "+lbSalidas.Text+"$, Ganancia: "+lbGanancia.Text+"$"; 
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "MABEJI Creaciones";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Húbo un error:"+ex.Message,"Error");
            }
            
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedor.Enabled ==true)
            {
                prov = "=" + cmbProveedor.SelectedValue;
            }
            grid();
        }

        private void cbCliente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbCliente_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbCliente.Checked==true)
            {
                cmbProveedor.Enabled = true;
                prov = "=" + cmbProveedor.SelectedValue;
            }
            else
            {
                cmbProveedor.Enabled = false;
                prov = "!=-1";
            }
            grid();
        }

        
    }
}
