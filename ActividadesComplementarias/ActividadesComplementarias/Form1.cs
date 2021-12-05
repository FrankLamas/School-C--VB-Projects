using System;
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
    public partial class MenuP : Form
    {
        public MenuP()
        {
            InitializeComponent();
        }

        private void datosEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void operacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarA aa = new AgregarA();
            aa.ShowDialog();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarA ma = new MostrarA();
            ma.ShowDialog();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alumnoBuscar ab = new alumnoBuscar();
            ab.ShowDialog();
        }

        private void actividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            actividadesAgregar aa = new actividadesAgregar();
            aa.ShowDialog();
        }

        private void mostrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            actividadesMostrar am = new actividadesMostrar();
            am.ShowDialog();
        }

        private void buscarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            actividadesBuscar ab = new actividadesBuscar();
            ab.ShowDialog();
        }

        private void mostrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            docentesMostar dm = new docentesMostar();
            dm.ShowDialog();
        }

        private void agregarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            docentesAgregar da = new docentesAgregar();
            da.ShowDialog();
        }

        private void buscarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            docentesBuscar db = new docentesBuscar();
            db.ShowDialog();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alumnosEditar ae = new alumnosEditar();
            ae.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alumnosEliminar ae = new alumnosEliminar();
            ae.ShowDialog();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            actividadesEditar ae = new actividadesEditar();
            ae.ShowDialog();
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            actividadesEliminar ae = new actividadesEliminar();
            ae.ShowDialog();
        }

        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            docentesEditar de = new docentesEditar();
            de.ShowDialog();
        }

        private void eliminarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            docentesEliminar de = new docentesEliminar();
            de.ShowDialog();
        }

        private void actividadADocenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignarTaller fat = new frmAsignarTaller();
            fat.ShowDialog();
        }

        private void tallerAAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOperacionesAsignarAlumnoATaller faat = new frmOperacionesAsignarAlumnoATaller();
            faat.ShowDialog();
        }

        private void verAlumnosIncritosYGenerarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGenerarListasAsistencia fgl = new frmGenerarListasAsistencia();
            fgl.ShowDialog();
        }

        private void justificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJustificarFaltas fjf = new frmJustificarFaltas();
            fjf.ShowDialog();
        }

        private void capturaDeAsistenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapturadeAsistencias fca = new frmCapturadeAsistencias();
            fca.ShowDialog();
        }

        private void realizarEvaluaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEvaluacion fe = new frmEvaluacion();
            fe.ShowDialog();
        }

        private void actaDeActividadesComplementariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmActadeActividadesComplementarias fac = new frmActadeActividadesComplementarias();
            fac.ShowDialog();
        }

        private void constanciaDeCumplimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmActadeCumplimiento fac = new frmActadeCumplimiento();
            fac.ShowDialog();
        }
    }
}
