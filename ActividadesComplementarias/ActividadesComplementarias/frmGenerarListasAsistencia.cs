using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ActividadesComplementarias
{
    public partial class frmGenerarListasAsistencia : Form
    {
        string ruta,periodo;
        public frmGenerarListasAsistencia()
        {
            InitializeComponent();
        }

        private void frmGenerarListasAsistencia_Load(object sender, EventArgs e)
        {
            try
            {
                String registro;
                ruta = Application.StartupPath + "\\Actividad.txt";
                using (StreamReader sr = new StreamReader(ruta))
                {
                    while ((registro = sr.ReadLine()) != null)
                    {
                        String[] datos = registro.Split(',');
                        this.cmbTaller.Items.Add(datos[1]);
                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(this, "No se encontro el archivo de talleres", "Error");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llenarDGV() {
            this.dgvInscritos.Rows.Clear();
            try
            {
                String registro;
                ruta = Application.StartupPath + "\\Registro.txt";
                using (StreamReader sr = new StreamReader(ruta))
                {
                    while ((registro = sr.ReadLine()) != null)
                    {
                        String[] datos = registro.Split(',');
                        if (datos[3] == cmbTaller.Text && datos[5] == cmbPer1.Text + " " + cmbPer2.Text)
                        {
                            this.dgvInscritos.Rows.Add(datos[0], datos[1], datos[2]);
                        }
                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(this, "No se encontro el archivo de Inscritos", "Error");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }

        private void cmbTaller_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarDGV();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                ruta = System.Windows.Forms.Application.StartupPath + "//listaAsistencia.xlsx";

                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Open(ruta);
                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo
                
                hoja_trabajo.Cells[9, 3] = cmbTaller.Text;
                hoja_trabajo.Cells[10, 3] = docente(cmbTaller.Text);
                hoja_trabajo.Cells[7, 2] = cmbPer1.Text + " " + cmbPer2.Text;
                for (int i = 0; i < dgvInscritos.Rows.Count; i++)
                {
                    hoja_trabajo.Cells[i + 13, 2] = dgvInscritos.Rows[i].Cells[1].Value.ToString();
                    hoja_trabajo.Cells[i + 13, 3] = dgvInscritos.Rows[i].Cells[2].Value.ToString();
                }

                //Fin del llenado
                libros_trabajo.PrintOutEx();
                libros_trabajo.Saved = true;
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }

        private string docente(string taller) {
            string docente = "";
            try
            {
                String registro;
                ruta = Application.StartupPath + "\\Actividad.txt";
                using (StreamReader sr = new StreamReader(ruta))
                {
                    Boolean x = false;
                    while ((registro = sr.ReadLine()) != null)
                    {
                        String[] datos = registro.Split(',');
                        if (taller == datos[1])
                        {
                            docente = datos[5];
                            x = true;
                        }
                    }
                    if (x != true)
                    {
                        MessageBox.Show(this, "No se encontraron coincidencias", "Sin resultados");
                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(this, "No se encontro el archivo", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }

            return docente;
        }

        private void cmbPer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarDGV();
        }

        private void cmbPer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarDGV();
        }
    }
}
