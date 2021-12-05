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
    public partial class frmCapturadeAsistencias : Form
    {
        string ruta;
        int idr = 0;
        public frmCapturadeAsistencias()
        {
            InitializeComponent();
        }

        private void frmCapturadeAsistencias_Load(object sender, EventArgs e)
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

        private void llenarDgv() {
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
            llenarDgv();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ruta = Application.StartupPath + "\\Asistencia.txt";
            //Aquí especificamos el idr para hacerlo incremental
            if (File.Exists(ruta))
            {
                try
                {
                    String registro;
                    ruta = Application.StartupPath + "\\Asistencia.txt";
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
            
            //Aquí va el registro del alumno
            try
            {
                ruta = Application.StartupPath + "\\Asistencia.txt";
                using (StreamWriter sw = File.AppendText(ruta))
                {
                    int n=0;
                    string[] fecha = dtpFecha.Text.Split(',');
                    while (n<dgvInscritos.Rows.Count)
                    {
                        sw.WriteLine(idr + "," + dgvInscritos[0, n].Value + "," + fecha[1] + "," + dgvInscritos[3, n].Value);
                        if (dgvInscritos[3, n].Value.ToString() == "Presente" || dgvInscritos[3, n].Value.ToString() == "Justificado")
                        {
                            string cmb = dgvInscritos[0, n].Value.ToString(); 
                            incrementarAsistencia(cmb); //Incrementar asistencia
                        }
                        n++;
                        idr++;
                    }
                    
                    sw.Close();
                    MessageBox.Show(this, "Registro Guardado", "Operación Realizada");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }
        private void incrementarAsistencia(String cmb) {
            try
            {
                Boolean dif = false;
                String ruta1 = Application.StartupPath + "\\Registro.txt";
                String ruta2 = Application.StartupPath + "\\temp1.txt";
                using (StreamWriter fileWrite = new StreamWriter(ruta2))
                {
                    using (StreamReader fielRead = new StreamReader(ruta1))
                    {
                        String line;

                        while ((line = fielRead.ReadLine()) != null)
                        {
                            string[] datos = line.Split(new char[] { ',' });
                            if (datos[0] != cmb)
                            {
                                fileWrite.WriteLine(line);
                            }
                            else
                            {
                                dif = true;
                                fileWrite.WriteLine(datos[0] + "," + datos[1] + "," + datos[2] + "," + datos[3] + "," + (Convert.ToInt16(datos[4]) + 1) + "," + datos[5]);
                            }
                        }
                        fileWrite.Close();
                        fielRead.Close();
                    }
                }

                //aqui se renombrea el archivo temporal 
                File.Delete(ruta1);
                File.Move(ruta2, ruta1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }

        private void cmbPer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarDgv();
        }

        private void cmbPer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarDgv();
        }
    }
}
