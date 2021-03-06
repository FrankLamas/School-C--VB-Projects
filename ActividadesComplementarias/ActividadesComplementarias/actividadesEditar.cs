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
    public partial class actividadesEditar : Form
    {
        String ruta;
        public actividadesEditar()
        {
            InitializeComponent();
        }

        private void actividadesEditar_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
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
                        if (tID.Text == datos[0])
                        {
                            tNombre.Text = datos[1];
                            tLugar.Text = datos[2];
                            tDia.Text = datos[3];
                            tHora.Text = datos[4];
                            x = true;
                            tNombre.Enabled = true;
                            tLugar.Enabled = true;
                            tDia.Enabled = true;
                            tHora.Enabled = true;
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (tID.Text == "" || tNombre.Text == "")
            {
                MessageBox.Show(this, "No puede haber campos vacios", "Error");
            }
            else
            {
                if (tNombre.Text != "")
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
                                    if (datos[0] != tID.Text)
                                    {
                                        fileWrite.WriteLine(line);
                                    }
                                    else
                                    {
                                        dif = true;
                                        fileWrite.WriteLine(tID.Text + "," + tNombre.Text + "," + (tLugar.Text == "" ? "N/A" : tLugar.Text) + "," + (tDia.Text == "" ? "N/A" : tDia.Text) + "," + (tHora.Text == "" ? "N/A" : tHora.Text) + "," + datos[5] + "," + datos[6]);
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
                        tLugar.Text = "";
                        tDia.Text = "";
                        tHora.Text = "";
                        if (dif==true)
                            MessageBox.Show(this, "Registro Guardado.", "Operación exitosa");
                        else
                            MessageBox.Show(this, "Registro Invalidado.", "Operación fallida");
                        
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
                    tLugar.Focus();
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

        private void tLugar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tNombre.Text == "")
                {
                    tLugar.Focus();
                }
                else
                {
                    tDia.Focus();
                }
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

        private void tDia_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tID.Text == "")
                {
                    tHora.Focus();
                }
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

        private void tID_TextChanged(object sender, EventArgs e)
        {
            tNombre.Text = "";
            tLugar.Text = "";
            tDia.Text = "";
            tHora.Text = "";
            tNombre.Enabled = false;
            tLugar.Enabled = false;
            tDia.Enabled = false;
            tHora.Enabled = false;
        }
    }
}
