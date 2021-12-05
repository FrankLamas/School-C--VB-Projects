using ProyectoClinica.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoClinica
{
    public partial class frmReceta : Form
    {
        int idh;
        public frmReceta(int idh)
        {
            this.idh = idh;
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tMedicamento.Text!=""&&tIndicaciones.Text!="")
	        {
		        int n = dgvCitas.Rows.Add();
                dgvCitas.Rows[n].Cells[0].Value = tMedicamento.Text;
                dgvCitas.Rows[n].Cells[1].Value = tIndicaciones.Text;
                tMedicamento.Text = "";
                tIndicaciones.Text = "";
	        }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            operaciones op = new operaciones();
            string[] datos = op.obtenerDatosReceta(idh);
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                string ruta = System.Windows.Forms.Application.StartupPath + "//Recetas.xlsx";

                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Open(ruta);
                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo

                hoja_trabajo.Cells[2, 3] = datos[0];
                hoja_trabajo.Cells[3, 2] = datos[1];
                hoja_trabajo.Cells[3, 4] = datos[2];
                hoja_trabajo.Cells[3, 6] = datos[3];
                hoja_trabajo.Cells[4, 3] = datos[4];
                for (int i = 0; i < dgvCitas.Rows.Count; i++)
                {
                    hoja_trabajo.Cells[i + 7, 1] = dgvCitas.Rows[i].Cells[0].Value.ToString();
                    hoja_trabajo.Cells[i + 7, 5] = dgvCitas.Rows[i].Cells[1].Value.ToString();
                }

                //Fin del llenado
                libros_trabajo.PrintOutEx();
                libros_trabajo.Saved = true;
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }

        private void tMedicamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tMedicamento.Text == "")
                {
                    tMedicamento.Focus();
                }
                else
                {
                    tIndicaciones.Focus();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsWhiteSpace(e.KeyChar))
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

        private void tIndicaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tIndicaciones.Text == "")
                {
                    tIndicaciones.Focus();
                }
                else
                {
                    tMedicamento.Focus();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsWhiteSpace(e.KeyChar))
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
    }
}
