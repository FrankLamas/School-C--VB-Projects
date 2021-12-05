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
    public partial class frmActadeActividadesComplementarias : Form
    {
        string ruta;
        public frmActadeActividadesComplementarias()
        {
            InitializeComponent();
        }

        private void frmActadeActividadesComplementarias_Load(object sender, EventArgs e)
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

        void desplegardatos() {
            this.dgvInscritos.Rows.Clear();
            try
            {
                String registro,registro2;
                ruta = Application.StartupPath + "\\Registro.txt";
                string ruta2 = Application.StartupPath + "\\Alumno.txt";
                using (StreamReader sr = new StreamReader(ruta))
                {
                    while ((registro = sr.ReadLine()) != null)
                    {
                        String[] datos = registro.Split(',');
                        if (datos[3] == cmbTaller.Text && datos[5] == cmbPer1.Text + " " + cmbPer2.Text)
                        {
                            using (StreamReader sr2 = new StreamReader(ruta2))
                            {
                                while ((registro2 = sr2.ReadLine()) != null)
                                {
                                    String[] datosA = registro2.Split(',');
                                    if (datosA[0] == datos[1])
                                    {
                                        this.dgvInscritos.Rows.Add(datos[1], datos[2], datosA[2],datosA[3],(Convert.ToInt16(datos[4])<3?"No Acredita":"Acredita"));
                                    }
                                }
                                sr2.Close();
                            }
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
            desplegardatos();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            desplegardatos();
        }

        private void cmbPer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            desplegardatos();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                ruta = System.Windows.Forms.Application.StartupPath + "//ACTAACTIVIDADESCOMPLEMENTARIAS.xlsx";

                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Open(ruta);
                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo

                hoja_trabajo.Cells[6, 4] = cmbTaller.Text;
                hoja_trabajo.Cells[7, 3] = docente(cmbTaller.Text);
                hoja_trabajo.Cells[4, 1] = cmbPer1.Text + " " + cmbPer2.Text;
                for (int i = 0; i < dgvInscritos.Rows.Count; i++)
                {
                    hoja_trabajo.Cells[i + 11, 2] = dgvInscritos.Rows[i].Cells[0].Value.ToString();
                    hoja_trabajo.Cells[i + 11, 3] = dgvInscritos.Rows[i].Cells[1].Value.ToString();
                    hoja_trabajo.Cells[i + 11, 5] = dgvInscritos.Rows[i].Cells[2].Value.ToString();
                    hoja_trabajo.Cells[i + 11, 6] = dgvInscritos.Rows[i].Cells[3].Value.ToString();
                    hoja_trabajo.Cells[i + 11, 8] = dgvInscritos.Rows[i].Cells[4].Value.ToString();
                }

                //Fin del llenado
                libros_trabajo.PrintOutEx();
                libros_trabajo.Saved = true;
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }
        private string docente(string taller)
        {
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
    }
}
