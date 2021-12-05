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
    public partial class frmEvaluacion : Form
    {
        int idr = 0;
        string ruta;
        public frmEvaluacion()
        {
            InitializeComponent();
        }

        private void frmEvaluacion_Load(object sender, EventArgs e)
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

        void llenardgv() {
            pictureBox2.Enabled = false;
            this.dgvInscritos.Rows.Clear();
            this.cmbImprimir.Items.Clear();
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
                            this.cmbImprimir.Items.Add(datos[2]);
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
            llenardgv();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ruta = Application.StartupPath + "\\Calificacion.txt";
            //Aquí especificamos el idr para hacerlo incremental
            if (File.Exists(ruta))
            {
                try
                {
                    String registro;
                    ruta = Application.StartupPath + "\\Calificacion.txt";
                    using (StreamReader sr = new StreamReader(ruta))
                    {
                        while ((registro = sr.ReadLine()) != null)
                        {
                            idr++;
                        }
                        sr.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error");
                }
            }

            //Aquí va el registro de las calificaciones
            try
            {
                ruta = Application.StartupPath + "\\Calificacion.txt";
                using (StreamWriter sw = File.AppendText(ruta))
                {
                    int n = 0;
                    while (n < dgvInscritos.Rows.Count)
                    {
                        int suma = Convert.ToInt16(dgvInscritos[3, n].Value)+Convert.ToInt16(dgvInscritos[4, n].Value)+Convert.ToInt16(dgvInscritos[5, n].Value)+
                            Convert.ToInt16(dgvInscritos[6, n].Value)+Convert.ToInt16(dgvInscritos[7, n].Value)+Convert.ToInt16(dgvInscritos[8, n].Value)+Convert.ToInt16(dgvInscritos[9, n].Value);
                        float promedio = (float)suma / 7;
                        string rubro;
                        if (promedio>=3.5)
                        {
                            rubro = "Excelente";
                        }
                        else if (promedio>=2.5)
                        {
                            rubro = "Notable";
                        }
                        else if (promedio >= 1.5)
                        {
                            rubro = "Bueno";
                        }
                        else if (promedio >= 1)
                        {
                            rubro = "Suficieente";
                        }
                        else
                        {
                            rubro = "Insuficiente";
                        }
                        sw.WriteLine(idr + "," + dgvInscritos[0, n].Value + "," + dgvInscritos[1, n].Value + "," + dgvInscritos[2, n].Value + "," + dgvInscritos[3, n].Value + ","
                            + dgvInscritos[4, n].Value + "," + dgvInscritos[5, n].Value + "," + dgvInscritos[6, n].Value + "," + dgvInscritos[7, n].Value + "," + dgvInscritos[8, n].Value + ","
                            + dgvInscritos[9, n].Value + "," + dgvInscritos[10, n].Value + "," + promedio + "," + rubro);
                        n++;
                        idr++;
                    }

                    sw.Close();
                    MessageBox.Show(this, "Registro Guardado", "Operación Realizada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }

        private void cmbPer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenardgv();
        }

        private void cmbPer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenardgv();
        }

        private void cmbImprimir_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox2.Enabled = true;
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
                ruta = System.Windows.Forms.Application.StartupPath + "//formatodeevaluación.xlsx";

                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Open(ruta);
                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo

                hoja_trabajo.Cells[13, 4] = cmbTaller.Text;
                hoja_trabajo.Cells[12, 4] = cmbImprimir.Text;
                hoja_trabajo.Cells[14, 4] = cmbPer1.Text + " " + cmbPer2.Text;
                
                
                for (int i = 0; i < dgvInscritos.Rows.Count; i++)
                {
                    if (cmbImprimir.Text == dgvInscritos.Rows[i].Cells[2].Value.ToString())
                    {
                        hoja_trabajo.Cells[18, 4 + (Convert.ToInt16(dgvInscritos.Rows[i].Cells[3].Value.ToString()) > 3 ? Convert.ToInt16(dgvInscritos.Rows[i].Cells[3].Value.ToString()) + 1 : Convert.ToInt16(dgvInscritos.Rows[i].Cells[3].Value.ToString()))] = "X";
                        hoja_trabajo.Cells[19, 4 + (Convert.ToInt16(dgvInscritos.Rows[i].Cells[4].Value.ToString()) > 3 ? Convert.ToInt16(dgvInscritos.Rows[i].Cells[4].Value.ToString()) + 1 : Convert.ToInt16(dgvInscritos.Rows[i].Cells[4].Value.ToString()))] = "X";
                        hoja_trabajo.Cells[20, 4 + (Convert.ToInt16(dgvInscritos.Rows[i].Cells[5].Value.ToString()) > 3 ? Convert.ToInt16(dgvInscritos.Rows[i].Cells[5].Value.ToString()) + 1 : Convert.ToInt16(dgvInscritos.Rows[i].Cells[5].Value.ToString()))] = "X";
                        hoja_trabajo.Cells[21, 4 + (Convert.ToInt16(dgvInscritos.Rows[i].Cells[6].Value.ToString()) > 3 ? Convert.ToInt16(dgvInscritos.Rows[i].Cells[6].Value.ToString()) + 1 : Convert.ToInt16(dgvInscritos.Rows[i].Cells[6].Value.ToString()))] = "X";
                        hoja_trabajo.Cells[22, 4 + (Convert.ToInt16(dgvInscritos.Rows[i].Cells[7].Value.ToString()) > 3 ? Convert.ToInt16(dgvInscritos.Rows[i].Cells[7].Value.ToString()) + 1 : Convert.ToInt16(dgvInscritos.Rows[i].Cells[7].Value.ToString()))] = "X";
                        hoja_trabajo.Cells[23, 4 + (Convert.ToInt16(dgvInscritos.Rows[i].Cells[8].Value.ToString()) > 3 ? Convert.ToInt16(dgvInscritos.Rows[i].Cells[8].Value.ToString()) + 1 : Convert.ToInt16(dgvInscritos.Rows[i].Cells[8].Value.ToString()))] = "X";
                        hoja_trabajo.Cells[24, 4 + (Convert.ToInt16(dgvInscritos.Rows[i].Cells[9].Value.ToString()) > 3 ? Convert.ToInt16(dgvInscritos.Rows[i].Cells[9].Value.ToString()) + 1 : Convert.ToInt16(dgvInscritos.Rows[i].Cells[9].Value.ToString()))] = "X";
                        //Datos de la evaluación
                        try
                        {
                            String registro;
                            ruta = Application.StartupPath + "\\Calificacion.txt";
                            using (StreamReader sr = new StreamReader(ruta))
                            {
                                while ((registro = sr.ReadLine()) != null)
                                {
                                    String[] datos = registro.Split(',');
                                    if (datos[3]==cmbImprimir.Text)
                                    {
                                        hoja_trabajo.Cells[30, 5] = datos[datos.Length - 2];
                                        hoja_trabajo.Cells[31, 6] = datos[datos.Length - 1];
                                    }
                                    
                                }
                                sr.Close();
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            MessageBox.Show(this, "No se encontro el archivo evaluación puede haber errores.", "Error");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, ex.Message, "Error");
                        }
                        //Fin datos de la evaluación

                        break;
                    }
                }

                //Fin del llenado
                libros_trabajo.PrintOutEx();
                libros_trabajo.Saved = true;
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }
        void buscarEvaluación() {
            try
            {
                String registro;
                ruta = Application.StartupPath + "\\Calificacion.txt";
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
    }
}
