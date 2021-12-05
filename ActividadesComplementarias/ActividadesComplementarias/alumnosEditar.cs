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
    public partial class alumnosEditar : Form
    {
        String ruta;
        public alumnosEditar()
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
                            x = true;
                            tNombre.Enabled = true;
                            tCarrera.Enabled = true;
                            tSeguro.Enabled = true;
                            tSangre.Enabled = true;
                            tSemestre.Enabled = true;
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
            if (tID.Text == "" || tNombre.Text == "" || tCarrera.Text == "" || tSemestre.Text == "" || tSeguro.Text == "" || tSangre.Text == "")
            {
                MessageBox.Show(this, "No puede haber casillas vacias", "error");
            }
            else
            {
                if (tNombre.Text != "")
                {
                    try
                    {
                        Boolean dif = true;
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
                                    else
                                    {
                                        fileWrite.WriteLine(tID.Text + "," + tNombre.Text + "," + tCarrera.Text + "," + tSemestre.Text + "," + tSeguro.Text + "," + tSangre.Text);
                                        dif = false;
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
                        if (dif == false)
                        {
                            MessageBox.Show(this, "Registro Guardado.", "Operación exitosa");
                        }
                        else
                        {
                            MessageBox.Show(this, "Registro no valido.", "Operación fallida");
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show(this, "No se encuentra el archivo.", "Error");
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
        }

        private void alumnosEditar_Load(object sender, EventArgs e)
        {
            tID.Focus();
        }

        private void tID_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void tNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tNombre.Text == "")
                {
                    tNombre.Focus();
                }
                else
                {
                    tCarrera.Focus();
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


        private void tSeguro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tID.Text == "")
                {
                    tSeguro.Focus();
                }
                else
                {
                    tSangre.Focus();
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
            tNombre.Enabled = false;
            tCarrera.Enabled = false;
            tSeguro.Enabled = false;
            tSangre.Enabled = false;
            tSemestre.Enabled = false;
        }
    }
}
