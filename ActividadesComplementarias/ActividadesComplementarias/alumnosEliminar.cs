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
    public partial class alumnosEliminar : Form
    {
        String ruta;
        public alumnosEliminar()
        {
            InitializeComponent();
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bBuscar_Click(object sender, EventArgs e)
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
                        if (tID.Text == datos[0])
                        {
                            tNombre.Text = datos[1];
                            tCarrera.Text = datos[2];
                            tSemestre.Text = datos[3];
                            tSeguro.Text = datos[4];
                            tSangre.Text = datos[5];
                            tTaller.Text = datos[6];
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
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (tNombre.Text != "" || tID.Text!= "") 
            {
                try
                {
                    String ruta1 = Application.StartupPath + "\\Alumno.txt";
                    String ruta2 = Application.StartupPath + "\\temp.txt";
                    using (StreamWriter fileWrite = new StreamWriter(ruta2))
                    {
                        using (StreamReader fielRead = new StreamReader(ruta1))
                        {
                            String line;

                            while ((line = fielRead.ReadLine()) != null)
                            {
                                string[] datos = line.Split(new char[] { ',' });
                                if (datos[0] != tID.Text)
                                {
                                    fileWrite.WriteLine(line);
                                }
                                else {
                                    decrementarTaller(datos[6]);
                                }
                            }
                            fileWrite.Close();
                            fielRead.Close();
                        }
                    }

                    //aqui se renombrea el archivo temporal 
                    File.Delete(ruta1);
                    File.Move(ruta2, ruta1);
                    tID.Text = "";
                    tNombre.Text = "";
                    tCarrera.Text = "";
                    tSeguro.Text = "";
                    tSangre.Text = "";
                    tSemestre.Text = "";
                    tTaller.Text = "";
                    MessageBox.Show(this, "Registro Borrado.", "Operación exitosa");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show(this, "Primero busca un registro valido.", "Error");
            }
        }

        private void tID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tID.Text == "")
            {
                tNombre.Text="";
                tCarrera.Text = "";
                tSeguro.Text = "";
                tSangre.Text = "";
                tSemestre.Text = "";
                tTaller.Text = "";
            }
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tID.Text == "")
                {
                    tID.Focus();
                }
                else
                {
                    tNombre.Focus();
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

        private void tID_TextChanged(object sender, EventArgs e)
        {
            tNombre.Text = "";
            tCarrera.Text = "";
            tSeguro.Text = "";
            tSangre.Text = "";
            tSemestre.Text = "";
            tTaller.Text = "";
        }

        void decrementarTaller(String cmb)
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
                                fileWrite.WriteLine(datos[0] + "," + datos[1] + "," + datos[2] + "," + datos[3] + "," + datos[4] + "," + datos[5] + "," + (Convert.ToInt16(datos[6]) - 1));
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
            catch (FileNotFoundException)
            {
                MessageBox.Show(this,"No se encontró el archivo de Talleres","");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }
    }
}
