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
    public partial class frmActadeCumplimiento : Form
    {
        string ruta;
        bool alumno = false;
        public frmActadeCumplimiento()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tSusc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tSusc.Text == "")
                {
                    tSusc.Focus();
                }
                else
                {
                    tNC.Focus();
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

        private void tNC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tNC.Text == "")
                {
                    tNC.Focus();
                }
                else
                {
                    tCiudad.Focus();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tCiudad.Text == "")
                {
                    tCiudad.Focus();
                }
                else
                {
                    tNC.Focus();
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

        private void tNC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String registro;
                ruta = Application.StartupPath + "\\Alumno.txt";
                using (StreamReader sr = new StreamReader(ruta))
                {
                    Boolean x = false;
                    while ((registro = sr.ReadLine()) != null)
                    {
                        String[] datos = registro.Split(',');
                        if (tNC.Text == datos[0])
                        {
                            lbDisponibleA.Visible = true;
                            lbDisponibleA.Text = "Alumno Existe";
                            lbDisponibleA.ForeColor = Color.Green;
                            x = true;
                            alumno = true;
                        }
                    }
                    if (x != true)
                    {
                        lbDisponibleA.Visible = true;
                        lbDisponibleA.Text = "Alumno no Existe";
                        lbDisponibleA.ForeColor = Color.Red;
                        alumno = false;
                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(this, "No se encontro el archivo de alumnos.", "Error");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (alumno == false)
            {
                MessageBox.Show(this, "No puedes imprimir si el alumno no existe o no cumplió con su asistencia.","Error");
            }
            else
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    ruta = System.Windows.Forms.Application.StartupPath + "//constanciadecumplimiento.xlsx";

                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Open(ruta);
                    hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                    //Recorremos el DataGridView rellenando la hoja de trabajo

                    hoja_trabajo.Cells[18, 5] = tSusc.Text;
                    hoja_trabajo.Cells[20, 3] = tNC.Text;
                    hoja_trabajo.Cells[26, 6] = tCiudad.Text;
                    hoja_trabajo.Cells[26, 10] = cmbDia.Text;
                    hoja_trabajo.Cells[26, 12] = cmbMes.Text;
                    hoja_trabajo.Cells[27, 2] = cmbAño.Text;

                    //Buscar en el archivo de alumno
                    try
                    {
                        String registro;
                        ruta = Application.StartupPath + "\\Alumno.txt";
                        using (StreamReader sr = new StreamReader(ruta))
                        {
                            Boolean x = false;
                            while ((registro = sr.ReadLine()) != null)
                            {
                                String[] datos = registro.Split(',');
                                if (tNC.Text == datos[0])
                                {
                                    hoja_trabajo.Cells[19, 7] = datos[1];
                                    hoja_trabajo.Cells[20, 8] = datos[2];
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
                        MessageBox.Show(this, "No se encontro el archivo de alumnos.", "Error");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Error");
                    }
                    //Fin buscar en el archivo de alumno
                    
                    //Buscar en Evaluación
                    try
                    {
                        String registro;
                        ruta = Application.StartupPath + "\\Calificacion.txt";
                        using (StreamReader sr = new StreamReader(ruta))
                        {
                            Boolean x = false;
                            while ((registro = sr.ReadLine()) != null)
                            {
                                String[] datos = registro.Split(',');
                                if (tNC.Text == datos[2])
                                {
                                    hoja_trabajo.Cells[21, 8] = datos[datos.Length - 1];
                                    hoja_trabajo.Cells[22, 2] = datos[datos.Length - 2];
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
                        MessageBox.Show(this, "No se encontro el archivo de Calificaciones.", "Error");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Error");
                    }
                    //Fin buscar en evaluación

                    //Busqueda en Registro
                    try
                    {
                        String registro;
                        ruta = Application.StartupPath + "\\Registro.txt";
                        using (StreamReader sr = new StreamReader(ruta))
                        {
                            Boolean x = false;
                            while ((registro = sr.ReadLine()) != null)
                            {
                                String[] datos = registro.Split(',');
                                if (tNC.Text == datos[1])
                                {
                                    hoja_trabajo.Cells[22, 8] = datos[5];
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
                        MessageBox.Show(this, "No se encontro el archivo de Inscritos.", "Error");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Error");
                    }
                    //Fin busqueda en registro

                    //Fin del llenado
                    libros_trabajo.PrintOutEx();
                    libros_trabajo.Saved = true;
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                }
            }
        }
    }
}
