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

namespace Agenda
{
    public partial class contactosEditar : Form
    {
        String ruta;
        public contactosEditar()
        {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                String registro;
                ruta = Application.StartupPath + "\\contacto.txt";
                using (StreamReader sr = new StreamReader(ruta))
                {
                    Boolean x = false;
                    while ((registro = sr.ReadLine()) != null)
                    {
                        String[] datos = registro.Split(',');
                        if (tID.Text == datos[0])
                        {
                            tNombre.Text = datos[1];
                            tDomicilio.Text = datos[2];
                            tTelefono.Text = datos[3];
                            tCorreo.Text = datos[4];
                            tNombre.Enabled = true;
                            tDomicilio.Enabled = true;
                            tTelefono.Enabled = true;
                            tCorreo.Enabled = true;
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
            if (tNombre.Text == "" || tID.Text == "" || tDomicilio.Text == "" || tTelefono.Text == "" || tCorreo.Text == "")
            {
                MessageBox.Show(this, "No puede haber casillas vacias", "Error");
            }
            else {
                if (tNombre.Text != "")
                {
                    try
                    {
                        Boolean dif = false;
                        String ruta1 = Application.StartupPath + "\\contacto.txt";
                        String ruta2 = Application.StartupPath + "\\temp.txt";
                        using (StreamReader fielRead = new StreamReader(ruta1))
                        {
                            using (StreamWriter fileWrite = new StreamWriter(ruta2))
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
                                        fileWrite.WriteLine(tID.Text + "," + tNombre.Text + "," + tDomicilio.Text + "," + tTelefono.Text + "," + tCorreo.Text);
                                        dif = true;
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
                        tDomicilio.Text = "";
                        tTelefono.Text = "";
                        tCorreo.Text = "";
                        if (dif == false)
                        {
                            MessageBox.Show(this, "Registro no valido.", "Operación fallida");
                        }
                        else {
                            MessageBox.Show(this, "Registro Modificado.", "Operación exitosa");
                        }
                        
                    }catch(FileNotFoundException){
                        MessageBox.Show(this, "No se encontro el archivo","Error");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Error");
                    }
                }
                else
                {
                    MessageBox.Show(this, "Primero busca un contacto valido.", "Error");
                }
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tDomicilio.Text == "")
                {
                    tDomicilio.Focus();
                }
                else
                {
                    tTelefono.Focus();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
            }
            else if (Char.IsLetterOrDigit(e.KeyChar) || Char.Equals(e.KeyChar, '-') || Char.Equals(e.KeyChar, '@') || Char.Equals(e.KeyChar, '_') || Char.Equals(e.KeyChar, '.'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tID.Text == "")
                {
                    tTelefono.Focus();
                }
                else
                {
                    tCorreo.Focus();
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
                    tDomicilio.Focus();
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

        private void tDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tDomicilio.Text == "")
                {
                    tDomicilio.Focus();
                }
                else
                {
                    tTelefono.Focus();
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

        private void tID_TextChanged(object sender, EventArgs e)
        {
            tNombre.Text = "";
            tDomicilio.Text = "";
            tTelefono.Text = "";
            tCorreo.Text = "";
            tNombre.Enabled = false;
            tDomicilio.Enabled = false;
            tTelefono.Enabled = false;
            tCorreo.Enabled = false;
        }

        private void contactosEditar_Load(object sender, EventArgs e)
        {

        }
    }
}
