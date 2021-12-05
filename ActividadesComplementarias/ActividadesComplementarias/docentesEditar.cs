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
    public partial class docentesEditar : Form
    {
        String ruta;
        public docentesEditar()
        {
            InitializeComponent();
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
                ruta = Application.StartupPath + "\\Docente.txt";
                using (StreamReader sr = new StreamReader(ruta))
                {
                    Boolean x = false;
                    while ((registro = sr.ReadLine()) != null)
                    {
                        String[] datos = registro.Split(',');
                        if (tID.Text == datos[0])
                        {
                            tNombre.Text = datos[1];
                            x = true;
                            tNombre.Enabled = true;
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
                MessageBox.Show(this, "No puede haber campos vacios antes de guardar", "Error");
            }
            else
            {
                if (tNombre.Text != "")
                {
                    try
                    {
                        Boolean dif = true;
                        String ruta1 = Application.StartupPath + "\\Docente.txt";
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
                                        fileWrite.WriteLine(tID.Text + "," + tNombre.Text);
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
                        if (dif == false)
                        {
                            MessageBox.Show(this, "Registro Guardado.", "Operación exitosa");
                        }
                        else
                        {
                            MessageBox.Show(this, "Registro no valido.", "Operación fallida");
                        }
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

        private void tNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tNombre.Text == "")
                {
                    tNombre.Focus();
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

        private void tID_TextChanged(object sender, EventArgs e)
        {
            tNombre.Text = "";
            tNombre.Enabled = false;
        }
    }
}
