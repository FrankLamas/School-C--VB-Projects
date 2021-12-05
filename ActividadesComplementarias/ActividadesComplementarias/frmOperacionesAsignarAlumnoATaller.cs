using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActividadesComplementarias
{
    public partial class frmOperacionesAsignarAlumnoATaller : Form
    {
        string ruta;
        int idr=0;
        bool taller = false;
        bool alumno = false;

        public frmOperacionesAsignarAlumnoATaller()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (textBox1.Text == "")
                {
                    textBox1.Focus();
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

        private void frmOperacionesAsignarAlumnoATaller_Load(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }

        private void cmbTaller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTaller.Text != "")
            {
                String Disp;
                int d = 0;
                Boolean enc = false;
                try
                {
                    String registro;
                    ruta = Application.StartupPath + "\\Actividad.txt";
                    using (StreamReader sr = new StreamReader(ruta))
                    {
                        while ((registro = sr.ReadLine()) != null)
                        {
                            String[] datos = registro.Split(',');
                            if (cmbTaller.Text == datos[1])
                            {
                                Disp = datos[6];
                                d = Convert.ToInt16(Disp);
                                enc = true;
                            }
                        }
                        sr.Close();
                    }
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show(this, "No se encontro el archivo de talleres", "Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error");
                }
                if (d < 20 && enc == true)
                {
                    lbDisponible.Visible = true;
                    lbDisponible.Text = "*Disponible";
                    lbDisponible.ForeColor = Color.Green;
                    taller = true;
                }
                else
                {
                    lbDisponible.Visible = true;
                    lbDisponible.Text = "*No Disponible";
                    lbDisponible.ForeColor = Color.Red;
                    taller = false;
                }
            }
            else
            {
                lbDisponible.Visible = false;
                taller = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                        if (textBox1.Text == datos[0])
                        {
                            lbDisponibleA.Visible = true;
                            lbDisponibleA.Text = "Alumno Existe";
                            lbDisponibleA.ForeColor = Color.Green;
                            tNombre.Text = datos[1];
                            tCarrera.Text = datos[2];
                            tSemestre.Text = datos[3];
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
                        tNombre.Text = "";
                        tCarrera.Text = "";
                        tSemestre.Text = "";
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
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (alumno == false || taller == false)
            {
                MessageBox.Show(this, "No puedes asignar si no hay disponibilidad o el alumno no existe", "error");
            }
            else
            {
                ruta = Application.StartupPath + "\\Registro.txt";
                //Aquí especificamos el idr para hacerlo incremental
                if (File.Exists(ruta))
                {
                    try
                    {
                        String registro;
                        ruta = Application.StartupPath + "\\Registro.txt";
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
                    ruta = Application.StartupPath + "\\Registro.txt";
                    using (StreamWriter sw = File.AppendText(ruta))
                    {              
                                   //idregistro     No de control       Nombre Alumno       Nombre Taller    No. Asistencias             Periodo
                        sw.WriteLine(idr + "," + textBox1.Text + "," + tNombre.Text + "," + cmbTaller.Text + "," + 0 + "," + cmbPeriodo1.Text + " " + cmbPeriodo2.Text);
                        sw.Close();
                        MessageBox.Show(this, "Registro Guardado", "Operación Realizada");
                        incrementarTaller(cmbTaller.Text);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error");
                }
            }
        }

        void incrementarTaller(String cmb)
        {
            try
            {
                Boolean dif = false;
                String ruta1 = Application.StartupPath + "\\Actividad.txt";
                String ruta2 = Application.StartupPath + "\\temp1.txt";
                using (StreamWriter fileWrite = new StreamWriter(ruta2))
                {
                    using (StreamReader fielRead = new StreamReader(ruta1))
                    {
                        String line;

                        while ((line = fielRead.ReadLine()) != null)
                        {
                            string[] datos = line.Split(new char[] { ',' });
                            if (datos[1] != cmb)
                            {
                                fileWrite.WriteLine(line);
                            }
                            else
                            {
                                dif = true;
                                fileWrite.WriteLine(datos[0] + "," + datos[1] + "," + datos[2] + "," + datos[3] + "," + datos[4] + "," + datos[5] + "," + (Convert.ToInt16(datos[6]) + 1));
                            }
                        }
                        fileWrite.Close();
                        fielRead.Close();
                    }
                }

                //aqui se renombrea el archivo temporal 
                File.Delete(ruta1);
                File.Move(ruta2, ruta1);
                if (dif == true)
                    MessageBox.Show(this, "Registro Taller Cambiado.", "Operación exitosa");
                else
                    MessageBox.Show(this, "Registro Taller Falló.", "Operación fallida");

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }
    }
}
