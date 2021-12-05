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
    public partial class frmAsignarTaller : Form
    {
        String ruta;
        public frmAsignarTaller()
        {
            InitializeComponent();
        }

        private void frmAsignarTaller_Load(object sender, EventArgs e)
        {
            try
            {
                String registro;
                ruta = Application.StartupPath + "\\Docente.txt";
                using (StreamReader sr = new StreamReader(ruta))
                {
                    while ((registro = sr.ReadLine()) != null)
                    {
                        String[] datos = registro.Split(',');
                        this.cmbDocente.Items.Add(datos[1]);
                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(this, "No se encontro el archivo de Docentes", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsDigit(e.KeyChar) || Char.Equals(e.KeyChar, ':'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tLugar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (cmbDocente.Text != "")
            {
                try
                {
                    Boolean dif = false;
                    String ruta1 = Application.StartupPath + "\\Actividad.txt";
                    String ruta2 = Application.StartupPath + "\\temp.txt";
                    using (StreamWriter fileWrite = new StreamWriter(ruta2))
                    {
                        using (StreamReader fielRead = new StreamReader(ruta1))
                        {
                            String line;

                            while ((line = fielRead.ReadLine()) != null)
                            {
                                string[] datos = line.Split(new char[] { ',' });
                                if (datos[1] != cmbTaller.Text)
                                {
                                    fileWrite.WriteLine(line);
                                }
                                else
                                {
                                    if (datos[5] == "N/A") {
                                        dif = true;
                                        fileWrite.WriteLine(datos[0] + "," + cmbTaller.Text + "," + (tLugar.Text == "" ? "N/A" : tLugar.Text) + "," + (cmbDia.Text == "" ? "N/A" : cmbDia.Text) + "," + (tHora.Text == "" ? "N/A" : tHora.Text) + "," + cmbDocente.Text + "," + datos[6]);
                                    }
                                    else {
                                        var respuesta = MessageBox.Show(this, "Esta actividad ya tiene un docente asignado, ¿te gustaría reasignar con los valores ingresados?","Atención",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                                        if (respuesta == DialogResult.No)
                                        {
                                            fileWrite.WriteLine(line);

                                        }
                                        else{
                                            dif = true;
                                            fileWrite.WriteLine(datos[0] + "," + cmbTaller.Text + "," + (tLugar.Text == "" ? "N/A" : tLugar.Text) + "," + (cmbDia.Text == "" ? "N/A" : cmbDia.Text) + "," + (tHora.Text == "" ? "N/A" : tHora.Text) + "," + cmbDocente.Text + "," + datos[6]);
                                        }
                                    }
                                    
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
                        MessageBox.Show(this, "Asignación Realizada.", "Operación exitosa");
                    else
                        MessageBox.Show(this, "Opercación No Realizada.", "No hubo cambios");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error");
                }
            }
            else {
                MessageBox.Show(this, "No ha seleccionado un docente.", "Operación no valida");
            }
            
        }

        private void cmbTaller_SelectedIndexChanged(object sender, EventArgs e)
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
                        if (datos[1] == cmbTaller.Text)
                        {
                            cmbDocente.Text = datos[5];
                            cmbDia.Text = datos[3];
                            tHora.Text = datos[4];
                            tLugar.Text = datos[2];
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
        }
    }
}
