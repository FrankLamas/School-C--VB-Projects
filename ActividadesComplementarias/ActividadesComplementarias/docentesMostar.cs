﻿using System;
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
    public partial class docentesMostar : Form
    {
        String ruta;
        public docentesMostar()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void docentesMostar_Load(object sender, EventArgs e)
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
                        this.dgvDocentes.Rows.Add(datos[0], datos[1]);
                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(this, "No se encontro el archivo", "Error");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }
    }
}
