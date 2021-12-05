using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlInventarios
{
    public partial class FormImprimirInventario : Form
    {
        DataTable dt;
        public FormImprimirInventario(DataTable datos)
        {
            dt = datos;
            InitializeComponent();
        }

        private DataTable dibujarTabla()
        {
            Inventario.ZapatosDataTable dtReporte = new Inventario.ZapatosDataTable();
            //Así se recorre un datatable ;)
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //object imagen = @dt.Rows[i]["Foto"];
                Inventario.ZapatosRow row = dtReporte.NewZapatosRow();
                row.Foto = File.ReadAllBytes(@dt.Rows[i]["Foto"].ToString());
                //row.Foto = File.ReadAllBytes(Path.Combine(Application.StartupPath, @"Imagenes\intellinet_logo.gif"));
                //Console.WriteLine(Path.Combine(Application.StartupPath, @"Imagenes\intellinet_logo.gif"));
                row.Modelo = @dt.Rows[i]["Modelo"].ToString();
                row.Numeracion = @dt.Rows[i]["Numeracion"].ToString();
                row.Stock = @dt.Rows[i]["Stock"].ToString();
                row.Tipo = @dt.Rows[i]["Tipo"].ToString();
                row.Precio = @dt.Rows[i]["Precio"].ToString();
                row.Color = @dt.Rows[i]["Color"].ToString();
                dtReporte.Rows.Add(row);
                //dataGridView1.Rows.Add(imagen, dt.Rows[i]["Modelo"], dt.Rows[i]["Numeracion"], dt.Rows[i]["Stock"], dt.Rows[i]["Tipo"], dt.Rows[i]["Precio"], dt.Rows[i]["Color"], dt.Rows[i]["idZapatos"]);
            }
            return dtReporte;
        }

        private void FormImprimirInventario_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", dibujarTabla());
            //dataGridView1.DataSource = dibujarTabla();
            reportViewer1.LocalReport.DataSources.Add(rds);
            //reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Report1.rdlc");

            ////reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(rds);
            //reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
