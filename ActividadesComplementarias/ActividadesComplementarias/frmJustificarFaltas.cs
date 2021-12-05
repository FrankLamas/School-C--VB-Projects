using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ActividadesComplementarias
{
    public partial class frmJustificarFaltas : Form
    {
        string ruta;
        bool x = false;
        public frmJustificarFaltas()
        {
            InitializeComponent();
        }

        private void frmJustificarFaltas_Load(object sender, EventArgs e)
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
                        this.cmbTaller.Items.Add(datos[1]);
                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(this, "No se encontro el archivo de talleres", "Error");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void desplegarDatos() {
            if (x!=false)
            {
                string[] fecha = dtpFecha.Text.Split(',');
                dgvJustificar.Rows.Clear();
                try
                {
                    string ruta2;
                    string registro;
                    ruta = Application.StartupPath + "\\Asistencia.txt";
                    ruta2 = Application.StartupPath + "\\Registro.txt";
                    using (StreamReader sr = new StreamReader(ruta))
                    {
                        while ((registro = sr.ReadLine()) != null)
                        {
                            String[] dAsist = registro.Split(',');
                            if (dAsist[2]==fecha[1])
                            {
                                using (StreamReader sr2 = new StreamReader(ruta2))
                                {
                                    while ((registro = sr2.ReadLine()) != null)
                                    {
                                        String[] dReg = registro.Split(',');
                                        if (dReg[0] == dAsist[1] && dReg[3]==cmbTaller.Text)
                                        {
                                            //Aquí se hace la muestra de datos
                                            this.dgvJustificar.Rows.Add(dAsist[0], dAsist[1], dReg[2], dAsist[3]);
                                        }
                                    }
                                    sr2.Close();
                                }
                            }
                        }
                        sr.Close();
                    }
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show(this, "No se encontro el archivo de Asistencias", "Error");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error");
                }
            }
            
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (cmbTaller.Text!="")
            {
                x = true;
                desplegarDatos();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean dif = false;
                String ruta1 = Application.StartupPath + "\\Asistencia.txt";
                String ruta2 = Application.StartupPath + "\\temp.txt";
                using (StreamWriter fileWrite = new StreamWriter(ruta2))
                {
                    using (StreamReader fileRead = new StreamReader(ruta1))
                    {
                        String line;
                        bool cambiar = false;
                        string estatus = "";
                        while ((line = fileRead.ReadLine()) != null)
                        {
                            string[] datos = line.Split(new char[] { ',' });
                            for (int i = 0; i < this.dgvJustificar.Rows.Count; i++)
                            {
                                if (datos[0] == dgvJustificar[0, i].Value.ToString() && datos[3] != dgvJustificar[3, i].Value.ToString())
                                {
                                    cambiar = true;
                                    estatus = dgvJustificar[3, i].Value.ToString();
                                    break;
                                }
                            }

                            if (cambiar!=true)
                            {
                                fileWrite.WriteLine(line);
                            }
                            else
                            {
                                dif = true;
                                fileWrite.WriteLine(datos[0] + "," + datos[1] + "," + datos[2] + "," + estatus);
                                if (estatus != "Ausente")
                                {
                                    if (datos[3] == "Presente" || datos[3] == "Justificado")
                                    {

                                    }
                                    else
                                    {
                                        incrementarAsistencia(datos[1]);
                                    }
                                }
                                else
                                {
                                    decrementarAsistencia(datos[1]);
                                }
                            }
                            cambiar = false;
                        }
                        fileWrite.Close();
                        fileRead.Close();
                    }
                }

                //aqui se renombrea el archivo temporal 
                File.Delete(ruta1);
                File.Move(ruta2, ruta1);
                if (dif == true)
                    MessageBox.Show(this, "Registro Guardado.", "Operación exitosa");
                else
                    MessageBox.Show(this, "Registro Invalidado.", "Operación fallida");

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }

        private void incrementarAsistencia(String cmb)
        {
            try
            {
                Boolean dif = false;
                String ruta1 = Application.StartupPath + "\\Registro.txt";
                String ruta2 = Application.StartupPath + "\\temp1.txt";
                using (StreamWriter fileWrite = new StreamWriter(ruta2))
                {
                    using (StreamReader fielRead = new StreamReader(ruta1))
                    {
                        String line;

                        while ((line = fielRead.ReadLine()) != null)
                        {
                            string[] datos = line.Split(new char[] { ',' });
                            if (datos[0] != cmb)
                            {
                                fileWrite.WriteLine(line);
                            }
                            else
                            {
                                dif = true;
                                fileWrite.WriteLine(datos[0] + "," + datos[1] + "," + datos[2] + "," + datos[3] + "," + (Convert.ToInt16(datos[4]) + 1) + "," + datos[5]);
                            }
                        }
                        fileWrite.Close();
                        fielRead.Close();
                    }
                }

                //aqui se renombrea el archivo temporal 
                File.Delete(ruta1);
                File.Move(ruta2, ruta1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }

        private void decrementarAsistencia(String cmb)
        {
            try
            {
                Boolean dif = false;
                String ruta1 = Application.StartupPath + "\\Registro.txt";
                String ruta2 = Application.StartupPath + "\\temp1.txt";
                using (StreamWriter fileWrite = new StreamWriter(ruta2))
                {
                    using (StreamReader fielRead = new StreamReader(ruta1))
                    {
                        String line;

                        while ((line = fielRead.ReadLine()) != null)
                        {
                            string[] datos = line.Split(new char[] { ',' });
                            if (datos[0] != cmb)
                            {
                                fileWrite.WriteLine(line);
                            }
                            else
                            {
                                dif = true;
                                fileWrite.WriteLine(datos[0] + "," + datos[1] + "," + datos[2] + "," + datos[3] + "," + (Convert.ToInt16(datos[4]) - 1));
                            }
                        }
                        fileWrite.Close();
                        fielRead.Close();
                    }
                }

                //aqui se renombrea el archivo temporal 
                File.Delete(ruta1);
                File.Move(ruta2, ruta1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }
        private void cmbTaller_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgvJustificar.Rows.Clear();
        }
    }
}
