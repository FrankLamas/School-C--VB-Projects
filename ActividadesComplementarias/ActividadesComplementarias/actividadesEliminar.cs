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
    public partial class actividadesEliminar : Form
    {
        String ruta;
        public actividadesEliminar()
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
                            tDocente.Text = datos[5];
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (tNombre.Text != "")
            {
                try
                {
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
                    tDocente.Text = "";
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

        private void tID_TextChanged(object sender, EventArgs e)
        {
            tNombre.Text = "";
            tLugar.Text = "";
            tDia.Text = "";
            tHora.Text = "";
            tDocente.Text = "";
        }
    }
}
