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
    public partial class AgregarA : Form
    {
        String ruta;
        public AgregarA()
        {
            InitializeComponent();
        }

        private void AgregarA_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (tID.Text == "" || tNombre.Text == "" || tDir.Text == "" || tTelefono.Text == "" || tCorreo.Text == "" || tSangre.Text == "")
            {
                MessageBox.Show(this,"No puede haber casillas vacias.","error");
            }
            else
            {
                try
                {
                    ruta = Application.StartupPath + "\\Alumno.txt";
                    using (StreamWriter sw = File.AppendText(ruta))
                    {
                        sw.WriteLine(tID.Text + "," + tNombre.Text + "," + tDir.Text + "," + tTelefono.Text + "," + tCorreo.Text + "," + tSangre.Text);
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
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
                    tDir.Focus();
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

        private void tCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tID.Text == "")
                {
                    tCorreo.Focus();
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

        void incrementarTaller(String cmb)
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
                            if (datos[1] != cmb)
                            {
                                fileWrite.WriteLine(line);
                            }
                            else
                            {
                                dif = true;
                                fileWrite.WriteLine(datos[0] + "," + datos[1] + "," + datos[2] + "," + datos[3] + "," + datos[4] + "," + datos[5] + "," + (Convert.ToInt16(datos[6])+1));
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
