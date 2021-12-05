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
    public partial class contactosEliminar : Form
    {
        String ruta;
        Boolean val=true;
        public contactosEliminar()
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
                            x = true;
                            val = true;
                        }
                    }
                    if (x != true)
                    {
                        MessageBox.Show(this, "No se encontraron coincidencias", "Sin resultados");
                        val = false;
                    }
                    sr.Close();
                }
            }catch(FileNotFoundException f){
                MessageBox.Show(this,"No se encuentra el archivo","Error");
                val = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
                val = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (tNombre.Text != "" && tID.Text!="" && val!=false)
            {
                try
                {
                    String ruta1 = Application.StartupPath + "\\contacto.txt";
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
                    MessageBox.Show(this, "Registro Borrado.", "Operación exitosa");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error");
                }
            }
            else {
                MessageBox.Show(this, "Primero busca un registro valido.", "Error");
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tID.Text == "")
            {
                tNombre.Text = "";
                tDomicilio.Text = "";
                tTelefono.Text = "";
                tCorreo.Text = "";
            }
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = false;
                if (tID.Text == "")
                {
                    tID.Focus();
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
            val = false;
            tNombre.Text = "";
            tDomicilio.Text = "";
            tTelefono.Text = "";
            tCorreo.Text = "";
        }
    }
}
