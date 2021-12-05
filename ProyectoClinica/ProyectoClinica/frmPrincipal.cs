using ProyectoClinica.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoClinica
{
    public partial class frmPrincipal : Form
    {
        string tabla = "";
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvPrincipal.Visible = true;
            lbApartado.Text = "Pacientes";
            tbFiltro.Visible = true;
            btnNuevo.Visible = true;
            btnEditar.Visible = true;
            btnImprimir.Visible = false;
            tabla = "paciente";
            button6.Visible = false;
            lbfiltro.Visible = true;
            lbReporte1.Visible = false;
            lbReporte2.Visible = false;
            dtpFecha.Visible = false;
            dtpFecha2.Visible = false;
            //datos del grid
            operaciones op = new operaciones();
            dgvPrincipal.DataSource = op.datosParaGrid(tabla);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgvPrincipal.Visible = true;
            lbApartado.Text = "Generar Reportes";
            tbFiltro.Visible = false;
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnImprimir.Visible = false;
            tabla = "Reportes";
            button6.Visible = true;
            button6.Text = "Generar Reporte";
            lbfiltro.Visible = false;
            lbReporte1.Visible = true;
            lbReporte2.Visible = true;
            dtpFecha.Visible = true;
            dtpFecha2.Visible = true;
            //datos del grid
            operaciones op = new operaciones();
            dgvPrincipal.DataSource = op.datosParaGridReporte(dtpFecha.Text,dtpFecha2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgvPrincipal.Visible = true;
            lbApartado.Text = "Citas Médicas";
            tbFiltro.Visible = true;
            btnNuevo.Visible = true;
            btnEditar.Visible = true;
            btnImprimir.Visible = false;
            tabla = "cita";
            button6.Visible = false;
            lbfiltro.Visible = true;
            lbReporte1.Visible = false;
            lbReporte2.Visible = false;
            dtpFecha.Visible = false;
            dtpFecha2.Visible = false;
            //datos del grid
            operaciones op = new operaciones();
            dgvPrincipal.DataSource = op.datosParaGridCitas();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dgvPrincipal.Visible = true;
            lbApartado.Text = "Historias Clinicas";
            tbFiltro.Visible = true;
            btnNuevo.Visible = true;
            btnEditar.Visible = true;
            btnImprimir.Visible = false;
            tabla = "historiasclinicas";
            button6.Visible = true;
            button6.Text = "Generar Receta";
            lbfiltro.Visible = true;
            lbReporte1.Visible = false;
            lbReporte2.Visible = false;
            dtpFecha.Visible = false;
            dtpFecha2.Visible = false;
            //datos del grid
            operaciones op = new operaciones();
            dgvPrincipal.DataSource = op.datosParaGridHistoriasClinicas();
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
             if (dgvPrincipal.Rows.Count != 0)
            {
                if (tabla == "Reportes")
                {
                    SaveFileDialog fichero = new SaveFileDialog();
                    fichero.Filter = "Excel (*.xls)|*.xls";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application aplicacion;
                        Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                        string ruta = System.Windows.Forms.Application.StartupPath + "//Reportes.xlsx";

                        aplicacion = new Microsoft.Office.Interop.Excel.Application();
                        libros_trabajo = aplicacion.Workbooks.Open(ruta);
                        hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                        //Recorremos el DataGridView rellenando la hoja de trabajo

                        hoja_trabajo.Cells[2, 3] = dtpFecha.Text;
                        hoja_trabajo.Cells[2, 5] = dtpFecha2.Text;
                        for (int i = 0; i < dgvPrincipal.Rows.Count; i++)
                        {
                            hoja_trabajo.Cells[i + 4, 1] = dgvPrincipal.Rows[i].Cells[0].Value.ToString();
                            hoja_trabajo.Cells[i + 4, 2] = dgvPrincipal.Rows[i].Cells[1].Value.ToString();
                            hoja_trabajo.Cells[i + 4, 3] = dgvPrincipal.Rows[i].Cells[2].Value.ToString();
                            hoja_trabajo.Cells[i + 4, 4] = dgvPrincipal.Rows[i].Cells[3].Value.ToString();
                            hoja_trabajo.Cells[i + 4, 5] = dgvPrincipal.Rows[i].Cells[4].Value.ToString();
                            hoja_trabajo.Cells[i + 4, 6] = dgvPrincipal.Rows[i].Cells[5].Value.ToString();
                        }

                        //Fin del llenado
                        libros_trabajo.PrintOutEx();
                        libros_trabajo.Saved = true;
                        libros_trabajo.Close(true);
                        aplicacion.Quit();
                    }
                }
                else if (tabla == "historiasclinicas")
                {
                    frmReceta fr = new frmReceta(Convert.ToInt16(dgvPrincipal.CurrentRow.Cells[0].Value.ToString()));
                    fr.ShowDialog();
                }
            }
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            dgvPrincipal.Visible = false;
            lbApartado.Text = "¡Bienvenido!";
            tbFiltro.Visible = false;
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnImprimir.Visible = false;
            button6.Visible = false;
            lbfiltro.Visible = false;
            lbReporte1.Visible = false;
            lbReporte2.Visible = false;
            dtpFecha.Visible = false;
            dtpFecha2.Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (tabla == "paciente") {
                frmAgregarPaciente ne = new frmAgregarPaciente();
                ne.ShowDialog();
                operaciones op = new operaciones();
                dgvPrincipal.DataSource = op.datosParaGrid(tabla);
            }
            else if (tabla == "cita")
            {
                frmAgregarCita ac = new frmAgregarCita();
                ac.ShowDialog();
                operaciones op = new operaciones();
                dgvPrincipal.DataSource = op.datosParaGridCitas();
            }
            else if (tabla=="historiasclinicas")
            {
                frmAgregarHistoria ah = new frmAgregarHistoria();
                ah.ShowDialog();
                operaciones op = new operaciones();
                dgvPrincipal.DataSource = op.datosParaGridHistoriasClinicas();
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tabla=="paciente")
            {
                frmEditarPaciente fe = new frmEditarPaciente(Convert.ToInt16(dgvPrincipal.CurrentRow.Cells[0].Value.ToString()));
                fe.ShowDialog();
                operaciones op = new operaciones();
                dgvPrincipal.DataSource = op.datosParaGrid(tabla);
            }
            else if(tabla=="cita")
            {
                frmEditarCita fec = new frmEditarCita(Convert.ToInt16(dgvPrincipal.CurrentRow.Cells[1].Value.ToString()));
                fec.ShowDialog();
                operaciones op = new operaciones();
                dgvPrincipal.DataSource = op.datosParaGridCitas();
            }
            else if (tabla=="historiasclinicas")
            {
                frmEditarHistoria feh = new frmEditarHistoria(Convert.ToInt16(dgvPrincipal.CurrentRow.Cells[0].Value.ToString()));
                feh.ShowDialog();
                operaciones op = new operaciones();
                dgvPrincipal.DataSource = op.datosParaGridHistoriasClinicas();
            }
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            if (tabla=="paciente")
            {
                operaciones op = new operaciones();
                dgvPrincipal.DataSource = op.filtroParaPaciente(tbFiltro.Text);
            }
            else if (tabla=="cita")
            {
                operaciones op = new operaciones();
                dgvPrincipal.DataSource = op.filtroCita(tbFiltro.Text);
            }
            else if (tabla=="historiasclinicas")
            {
                operaciones op = new operaciones();
                dgvPrincipal.DataSource = op.filtroHistoria(tbFiltro.Text);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            //datos del grid
            operaciones op = new operaciones();
            dgvPrincipal.DataSource = op.datosParaGridReporte(dtpFecha.Text, dtpFecha2.Text);
        }

        private void dtpFecha2_ValueChanged(object sender, EventArgs e)
        {
            //datos del grid
            operaciones op = new operaciones();
            dgvPrincipal.DataSource = op.datosParaGridReporte(dtpFecha.Text, dtpFecha2.Text);
        }
    }
}
